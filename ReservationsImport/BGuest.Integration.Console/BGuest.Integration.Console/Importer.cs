using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using BGuest.Integration.Console.Model;
using Dapper;
using Mindscape.Raygun4Net;

namespace BGuest.Integration.Console
{
    public class Importer
    {
        private static readonly RaygunClient RaygunClient = new RaygunClient(ConfigurationManager.AppSettings["Raygun:ApiKey"]);
        private static readonly List<string> RaygunTags = new List<string> {"Reservations", "Import", "Console"};

        public static void SendToRaygun(Exception e)
        {
            RaygunClient.SendInBackground(e, RaygunTags);
        }

        public static StringBuilder Log { get; set; }

        static int Main(string[] args)
        {
            try
            {
                Log = new StringBuilder();
                Log.AppendFormat("Import start at {0}", DateTime.Now);
                Log.AppendLine();
                Log.AppendFormat("----Settings----");
                Log.AppendLine();

                var settings = ImporterSettingsFactories.GetFactory("File");
                RaygunTags.Add(settings.HotelDescription);

                Log.AppendFormat("Hotel {0}", settings.HotelDescription);
                Log.AppendLine();

                Log.AppendLine();
                Log.AppendFormat("Db client Provider {0}", settings.ConnectionString.ProviderName);
                Log.AppendLine();

                var dbFactory = DbProviderFactories.GetFactory(settings.ConnectionString.ProviderName);

                Log.AppendFormat("Db provider ok: " + dbFactory);
                Log.AppendLine();

                ImportTemplate(dbFactory, settings);
                Log.AppendLine();
                Log.AppendFormat("Import Ended at {0}", DateTime.Now);
                SendMail.ResultLogAsync(Log.ToString());
                System.Console.WriteLine(Log.ToString());
#if DEBUG
                System.Console.ReadKey();
#endif
                return 0;
            }
            catch(Exception e)
            {
                SendToRaygun(e);
                System.Console.WriteLine(e.Message);
                while (null != e.InnerException)
                {
                    e = e.InnerException;
                    System.Console.WriteLine(e.Message);
                }
#if DEBUG
                System.Console.WriteLine(Log.ToString());
                System.Console.ReadKey();
#endif
                return 112;
            }
        }

        public static void ImportTemplate(DbProviderFactory factory, ImporterSettingsFactory settings)
        {
            using (var conn = factory.CreateConnection())
            {
                Debug.Assert(conn != null, "conn != null");
                conn.ConnectionString = settings.ConnectionString.ConnectionString;
                var reservationsList = conn.Query<StayData>(settings.QueryString);
                var map = reservationsList
                    .GroupBy(x => x.HotelId)
                    .ToDictionary(x => x.Key, x => x.ToList());
                ResultLogger resultsLogger = new StringBuildResults();
                foreach (var key in map.Keys)
                {
                    var reservationsByHotel = new List<StayData>();
                    foreach (var reserv in map[key])
                    {
                        if (string.IsNullOrWhiteSpace(reserv.HotelId) || 
                            string.IsNullOrWhiteSpace(reserv.ExternalKey) ||
                            reserv.PeriodStart.Equals(DateTime.MinValue) ||
                            reserv.PeriodEnd.Equals(DateTime.MinValue) ||
                            string.IsNullOrWhiteSpace(reserv.GuestFirstName) ||
                            string.IsNullOrWhiteSpace(reserv.GuestLastName) ||
                            string.IsNullOrWhiteSpace(reserv.GuestEmail))
                        {
                            resultsLogger.AddResponse(new StayImportResultDto {
                                Success = false,
                                ExternalKey = reserv.ExternalKey,
                                GuestEmail = reserv.GuestEmail,
                                Message = @"Reservation has invalid values. " 
                                    + $"Hotel Id: {reserv.HotelId}; Start: {reserv.PeriodStart}; End: {reserv.PeriodEnd};" 
                                    + $"First Name: {reserv.GuestFirstName}; Last Name: {reserv.GuestLastName}"
                            });
                            continue;
                        }
                        reserv.Reservation = reserv.Reservation ?? reserv.ExternalKey;
                        reservationsByHotel.Add(reserv);
                    }
                    var recordCount = reservationsByHotel.Count;
                    const int batchSize = 100;
                    for (var index = 0; index < recordCount; index += batchSize)
                    {
                        var stays = reservationsByHotel.GetRange(index, Math.Min(batchSize, recordCount - index));
                        ImportStaysBatch(settings.HotelMapping(key), stays, resultsLogger, settings.BaseUri);  
                    }
                }
                Log.AppendLine();
                Log.Append(resultsLogger);
            }
        }

        private static void ImportStaysBatch(HotelMapping hotelMapping, List<StayData> stays, ResultLogger resultsLogger,
            string baseUriString)
        {
            var baseUri = new Uri(baseUriString);
            using (var client = new HttpClient {BaseAddress = baseUri})
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var apiKey = hotelMapping.ApiKey;
                var apiSecret = hotelMapping.ApiSecret;
                var requestApiUrl = $"api/v2/stays?apiKey={apiKey}&apiSecret={apiSecret}";

                var responseBGuest = client.PostAsJsonAsync(requestApiUrl, stays);
                responseBGuest.Wait();
                if (responseBGuest.Result.IsSuccessStatusCode)
                {
                    var res = responseBGuest.Result.Content.ReadAsAsync<List<StayImportResultDto>>();
                    res.Wait();
                    foreach (var reservationResult in res.Result)
                    {
                        resultsLogger.AddResponse(reservationResult);
                    }
                }
                else
                {
                    var exception = responseBGuest.Result.Content.ReadAsStringAsync().Result;
                    stays.ForEach(s=> resultsLogger.AddResponse(new StayImportResultDto {
                        Success = false,
                        ExternalKey = s.ExternalKey,
                        GuestEmail = s.GuestEmail,
                        Message = exception.ToString()
                    }));
                    System.Console.WriteLine($"Bad response {exception}");
                }

            }
        }

        public static void ImportTemplateWithDataReader(DbProviderFactory factory, ImporterSettingsFactory settings)
        {
                using (var connection = factory.CreateConnection())
                {
                    Debug.Assert(connection != null, "connection != null");
                    connection.ConnectionString = settings.ConnectionString.ConnectionString;
                    var command = factory.CreateCommand();
                    Debug.Assert(command != null, "command != null");
                    command.Connection = connection;
                    command.CommandText = settings.QueryString;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        List<StayData> stays = new List<StayData>();
                        int recordCount = 0;
                        int recordErrors = 0;
                        ResultLogger resultsLogger = new StringBuildResults();
                        while (reader.Read())
                        {
                            recordCount++;
                            try
                            {
                                var stay = new StayData
                                {
                                    Room = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                                    Reservation = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    PeriodStart = reader.GetDateTime(2),
                                    PeriodEnd = reader.GetDateTime(3),
                                    IsCheckedIn = Convert.ToBoolean(reader.GetByte(4)),
                                    AllowExpressCheckout = Convert.ToBoolean(reader.GetByte(5)),
                                    CurrentBillValue = (reader.IsDBNull(6) ? (double?)null : reader.GetDouble(6)),
                                    CurrentBillDate = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7),
                                    CurrentBillCurrency = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                                    IsBreakfastIncluded = Convert.ToBoolean(reader.GetByte(9)),
                                    GuestEmail = reader.IsDBNull(10) ? string.Empty : reader.GetString(10),
                                    GuestFirstName = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                                    GuestLastName = reader.IsDBNull(12) ? string.Empty : reader.GetString(12),
                                    GuestPhoneNumber = reader.IsDBNull(13) ? string.Empty : reader.GetString(13),
                                    ExternalKey = reader.IsDBNull(14) ? string.Empty : reader.GetString(14),
                                    State = (StayStates) Enum.Parse(typeof(StayStates), reader.GetString(15))
                                };
                                stays.Add(stay);
                            }
                            catch (Exception e)
                            {
                                //Log.AppendFormat("Error read {0}(Message:{1})", reader.GetString(14), e.Message);
                                //Log.AppendLine();
                                //SendToRaygun(e);
                                System.Console.WriteLine(e.Message);
                                recordErrors++;
                            }

                            if (1 == stays.Count)
                            {
                                //ImportStayBatch(settings, stays, resultsLogger);
                                stays.Clear();
                            }
                        }
                        reader.Close();
                        if (0 < stays.Count)
                        {
                            //ImportStayBatch(settings, stays, resultsLogger);
                        }
                        Log.AppendLine();
                        Log.AppendFormat("Found {0} records to import.", recordCount);
                        Log.AppendLine();
                        Log.AppendFormat("Found {0} records with errors.", recordErrors);
                        Log.Append(resultsLogger);
                    }
                }
        }
    }
}
