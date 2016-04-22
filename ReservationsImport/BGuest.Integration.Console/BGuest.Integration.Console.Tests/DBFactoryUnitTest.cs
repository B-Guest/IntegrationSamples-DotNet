using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using BGuest.Integration.Console;
using BGuest.Integration.Console.Model;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;


namespace BGuest.Integration.Console.Tests
{
    [TestClass]
    public class DBFactoryUnitTest
    {

        [TestMethod]
        public void InsertSqlData()
        {
            var connSettings = ConfigurationManager.ConnectionStrings["SqlConnection"];
            //var connSettings = ConfigurationManager.ConnectionStrings["OracleConnection"];
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connSettings.ProviderName);
            using (var connection = dbFactory.CreateConnection())
            {
                connection.ConnectionString = connSettings.ConnectionString;
                //connection.
                connection.Open();
                var cmd = dbFactory.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"
                    drop table reservations;
                    create table reservations 
		                (room varchar(10), 
		                reservation varchar(100), 
		                periodStart datetime, 
		                periodEnd datetime, 
		                isCheckedIn smallint, 
		                allowExpressCheckout smallint, 
		                currentBillValue decimal, 
		                currentBillDate datetime, 
		                currentBillCurrency varchar(100), 
		                isBreakfastIncluded smallint, 
		                guestEmail varchar(100), 
		                guestFirstName varchar(100), 
		                guestLastName varchar(100),
		                guestPhoneNumber varchar(100), 
		                externalKey varchar(100), 
		                [state] varchar(100));
                INSERT INTO [dbo].[reservations]
                           ([room]
                           ,[reservation]
                           ,[periodStart]
                           ,[periodEnd]
                           ,[isCheckedIn]
                           ,[allowExpressCheckout]
                           ,[currentBillValue]
                           ,[currentBillDate]
                           ,[currentBillCurrency]
                           ,[isBreakfastIncluded]
                           ,[guestEmail]
                           ,[guestFirstName]
                           ,[guestLastName]
                           ,[guestPhoneNumber]
                           ,[externalKey]
                           ,[state])
                select  row_number() over (order by Starts.date)  [room], row_number() over (order by Starts.date) Reservation,
	                Starts.date [periodStart], Ends.date [periodEnd], 
	                0 [isCheckedIn], 0 [allowExpressCheckout], 
	                null [currentBillValue], null [currentBillDate], null [currentBillCurrency], 
	                ABS(CHECKSUM(NewId())) % 2 [isBreakfastIncluded], firsts.name + '_' + lasts.name + '@example.pt' [guestEmail], 
	                firsts.name [guestFirstName], lasts.name [guestLastName], '+351 123 455 ' + cast(ABS(CHECKSUM(NewId())) % 1000 as varchar) [guestPhoneNumber], 
	                row_number() over (order by Starts.date) [externalKey], 
	                Case when ABS(CHECKSUM(NewId())) % 2 = 1 then 'Active' else 'Removed' end [state]
                from 
                    (VALUES (null),('Fred'), ('Bruno'), ('João'), ('Rui')) firsts (name),
                    (VALUES (null),('Tereso'), ('Moscao'), ('Vieira')) Lasts (name),
                    (VALUES (null),('2016-04-01'), ('2016-05-01'), ('2016-06-01')) Starts (date),
                    (VALUES (null),('2016-04-15'), ('2016-05-15'), ('2016-06-15')) Ends (date);";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();


                //var insertSql = @"INSERT INTO[dbo].[reservations]
                //           ([room]
                //           ,[reservation]
                //           ,[periodStart]
                //           ,[periodEnd]
                //           ,[isCheckedIn]
                //           ,[allowExpressCheckout]
                //           ,[currentBillValue]
                //           ,[currentBillDate]
                //           ,[currentBillCurrency]
                //           ,[isBreakfastIncluded]
                //           ,[guestEmail]
                //           ,[guestFirstName]
                //           ,[guestLastName]
                //           ,[guestPhoneNumber]
                //           ,[externalKey]
                //           ,[state])
                //     VALUES
                //           (@room
                //           ,@reservation
                //           ,@periodStart
                //           ,@periodEnd
                //           ,@isCheckedIn
                //           ,@allowExpressCheckout
                //           ,@currentBillValue
                //           ,@currentBillDate
                //           ,@currentBillCurrency
                //           ,@isBreakfastIncluded
                //           ,@guestEmail
                //           ,@guestFirstName
                //           ,@guestLastName
                //           ,@guestPhoneNumber
                //           ,@externalKey
                //           ,@state";
                //var parameter = dbFactory.CreateParameter();
                //parameter.ParameterName = "room";
                //cmd.Parameters.Add(parameter);
                //var da = dbFactory.CreateDataAdapter();
                //da.InsertCommand = cmd;
                //var dt = new DataTable();
 
                connection.Close();
            }
        }
        [TestMethod]
        public void InsertOracleData()
        {
            //var connSettings = ConfigurationManager.ConnectionStrings["SqlConnection"];
            var connSettings = ConfigurationManager.ConnectionStrings["OracleConnection"];
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connSettings.ProviderName);
            using (var connection = dbFactory.CreateConnection())
            {
                connection.ConnectionString = connSettings.ConnectionString;
                //connection.
                connection.Open();
                var cmd = dbFactory.CreateCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"
                    declare 
                        v_exists number := 0;
                    begin 
                        select count(1) into v_exists from user_tables where table_name = 'RESERVATIONS';
                        if v_exists > 0 then
                            execute immediate 'drop table reservations';
                        end if;
                    end;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                    create table reservations 
		                (room varchar(10), 
		                reservation varchar(100), 
		                periodStart date, 
		                periodEnd date, 
		                isCheckedIn number, 
		                allowExpressCheckout number, 
		                currentBillValue decimal, 
		                currentBillDate date, 
		                currentBillCurrency varchar(100), 
		                isBreakfastIncluded number, 
		                guestEmail varchar(100), 
		                guestFirstName varchar(100), 
		                guestLastName varchar(100),
		                guestPhoneNumber varchar(100), 
		                externalKey varchar(100), 
		                state varchar(100))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"
                     INSERT INTO reservations
                                (room
                                ,reservation
                                ,periodStart
                                ,periodEnd
                                ,isCheckedIn
                                ,allowExpressCheckout
                                ,currentBillValue
                                ,currentBillDate
                                ,currentBillCurrency
                                ,isBreakfastIncluded
                                ,guestEmail
                                ,guestFirstName
                                ,guestLastName
                                ,guestPhoneNumber
                                ,externalKey
                                ,state)
                        select  null --row_number() over (order by Starts.COLUMN_VALUE)  room,
                                ,null --'ORACLE' || row_number() over (order by Starts.COLUMN_VALUE) Reservation,
                                ,Starts.COLUMN_VALUE periodStart, Ends.COLUMN_VALUE periodEnd, 
	                            0 isCheckedIn, 0 allowExpressCheckout, 
	                            null currentBillValue, null currentBillDate, null currentBillCurrency, 
                                0 -- Round(dbms_random.value) isBreakfastIncluded,
                                ,firsts.COLUMN_VALUE || '_' || lasts.COLUMN_VALUE || '@example.pt' guestEmail, 
                                firsts.COLUMN_VALUE guestFirstName, lasts.COLUMN_VALUE guestLastName,
                                null-- '+351' || Round(dbms_random.value(200000000, 999999999)) guestPhoneNumber,
                                , null -- row_number() over (order by Starts.COLUMN_VALUE) externalKey, 
	                            ,Case when Round(dbms_random.value) = 1 then 'Active' else 'Removed' end state
                          from 
                                table(sys.dbms_debug_vc2coll('Fred', 'Bruno', 'João', 'Rui')) firsts,
                                table(sys.dbms_debug_vc2coll('Tereso', 'Moscao', 'Vieira')) Lasts,
                                table(sys.dbms_debug_vc2coll('2016-04-01', '2016-05-01', '2016-06-01')) Starts,
                                table(sys.dbms_debug_vc2coll('2016-04-15', '2016-05-15', '2016-06-15')) Ends";
                cmd.ExecuteNonQuery(); 
                connection.Close();
            }
        }
        [TestMethod]

        public void GetOracleDataAdapter()
        {
            Dictionary<string, List<StayData>> stays = new Dictionary<string, List<StayData>>();
            Importer.Log = new StringBuilder();
            MockSettings settings = new MockSettings("OracleConnection");
            DbProviderFactory factory = DbProviderFactories.GetFactory(settings.ConnectionString.ProviderName);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = settings.ConnectionString.ConnectionString;
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = settings.QueryString;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    Dictionary<string, int> columns = new Dictionary<string, int>();
                    for (int field = 0; field < reader.FieldCount; field++)
                    {
                        columns.Add(reader.GetName(field), field);
                    }
                    
                    
                    //Dictionary<string, StayData> stays = new Dictionary<string, StayData>();
                    while (reader.Read())
                    {
                        try
                        {
                            var stay = new StayData();
                            stay.HotelId = reader.GetString(columns["HOTELID"]);
                            stay.ExternalKey = reader.GetString(columns["EXTERNALKEY"]);
                            stay.PeriodStart = reader.GetDateTime(columns["PERIODSTART"]);
                            stay.PeriodEnd = reader.GetDateTime(columns["PERIODEND"]);

                            stay.GuestEmail = reader.GetString(columns["GUESTEMAIL"]);
                            stay.GuestFirstName = reader.GetString(columns["GUESTFIRSTNAME"]);
                            stay.GuestLastName = reader.GetString(columns["GUESTLASTNAME"]);

                            if (columns.ContainsKey("RESERVATION"))
                            {
                                stay.Reservation = reader.IsDBNull(columns["RESERVATION"])
                                    ? stay.ExternalKey
                                    : reader.GetString(columns["RESERVATION"]);
                            }
                            else
                            {
                                stay.Reservation = stay.ExternalKey;
                            }

                            if (columns.ContainsKey("ROOM")) stay.Room = reader.IsDBNull(columns["ROOM"]) ? string.Empty : reader.GetString(columns["ROOM"]);

                            // booleans
                            if (columns.ContainsKey("ISCHECKEDIN")) stay.IsCheckedIn = !reader.IsDBNull(columns["ISCHECKEDIN"]) && Convert.ToBoolean(reader.GetByte(columns["ISCHECKEDIN"]));
                            if (columns.ContainsKey("ALLOWEXPRESSCHECKOUT")) stay.AllowExpressCheckout = !reader.IsDBNull(columns["ALLOWEXPRESSCHECKOUT"]) && Convert.ToBoolean(reader.GetByte(columns["ALLOWEXPRESSCHECKOUT"]));
                            if (columns.ContainsKey("ISBREAKFASTINCLUDED")) stay.IsBreakfastIncluded = !reader.IsDBNull(columns["ISBREAKFASTINCLUDED"]) && Convert.ToBoolean(reader.GetByte(columns["ISBREAKFASTINCLUDED"]));

                            // doubles
                            if (columns.ContainsKey("CURRENTBILLVALUE")) stay.CurrentBillValue = (reader.IsDBNull(columns["CURRENTBILLVALUE"]) ? (double?)null : reader.GetDouble(columns["CURRENTBILLVALUE"]));
                            if (columns.ContainsKey("CURRENTBILLDATE")) stay.CurrentBillDate = (reader.IsDBNull(columns["CURRENTBILLDATE"]) ? (DateTime?)null : reader.GetDateTime(columns["CURRENTBILLDATE"]));
                            if (columns.ContainsKey("CURRENTBILLCURRENCY")) stay.CurrentBillCurrency = (reader.IsDBNull(columns["CURRENTBILLCURRENCY"]) ? string.Empty: reader.GetString(columns["CURRENTBILLCURRENCY"]));

                            if (columns.ContainsKey("GUESTPHONENUMBER")) stay.Room = reader.IsDBNull(columns["GUESTPHONENUMBER"]) ? string.Empty : reader.GetString(columns["GUESTPHONENUMBER"]);

                            if (columns.ContainsKey("State")) 
                                stay.State = (StayStates)Enum.Parse(typeof(StayStates), reader.GetString(15));
                            if (!stays.ContainsKey(stay.HotelId))
                            {
                                stays.Add(stay.HotelId, new List<StayData>());
                            }
                            stays[stay.HotelId].Add(stay);

                        }
                        catch (Exception e)
                        {

                            System.Console.WriteLine(e.Message);
                        }

                    }
                    reader.Close();
                }
            }

        }

        public void GetOracleData()
        {
            Importer.Log = new StringBuilder();
            MockSettings settings = new MockSettings("OracleConnection");
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(settings.ConnectionString.ProviderName);
            Importer.ImportTemplate(dbFactory, settings);
           // SendMail.ResultLogAsync(Importer.Log.ToString());
        }
        [TestMethod]
        public void CallApiWithOneRservation()
        {
            var stays = new List<StayData>();
            var stay = new StayData
            {
                Room = "quarto 234",
                Reservation = "Reserva",
                PeriodStart = new DateTime(2016, 6, 1),
                PeriodEnd = new DateTime(2016, 6, 15),
                IsCheckedIn = false,
                AllowExpressCheckout = false,
                CurrentBillValue = null,
                CurrentBillDate = null,
                CurrentBillCurrency = null,
                IsBreakfastIncluded = false,
                GuestEmail = "test@test.pt",
                GuestFirstName = "api",
                GuestLastName = "Test",
                GuestPhoneNumber = "+351 234 2342 234",
                ExternalKey = "tqetqert",
                State = (StayStates)Enum.Parse(typeof(StayStates), "Removed")
            };
            stays.Add(stay);
            //using (var client = new BGuestIntegrationClient("https://bguest-integration-api-prod.azurewebsites.net/",
            //    Guid.Parse("c4208720-03b8-4780-919b-970edf46d6d2"),
            //    "_UHJKRwSaDRPglUAekEWy0zd4sf1wZduDjwhsZVj7Dg1"
            //    ))
            //using (var client = new BGuestIntegrationClient("https://bguest-integration-api-dev.azurewebsites.net/",
            //    Guid.Parse("7aa3921f-d388-4015-9d23-f0ac3b919739"),
            //    "lnGI6XpfLYNe3SdwWCLF-qcn_zm67qk_EcGRfL-1zt81"
            //    ))
            var baseUri = new Uri("https://bguest-integration-api-dev.azurewebsites.net/");
            using (var client = new HttpClient{BaseAddress = baseUri})
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var apiKey = Guid.Parse("7aa3921f-d388-4015-9d23-f0ac3b919739");
                var apiSecret = "lnGI6XpfLYNe3SdwWCLF-qcn_zm67qk_EcGRfL-1zt81";
                var requestApiUrl = $"api/v2/stays?apiKey={apiKey}&apiSecret={apiSecret}";

                var responseBGuest = client.PostAsJsonAsync(requestApiUrl, stays);
                responseBGuest.Wait();
                var res = responseBGuest.Result.Content.ReadAsAsync<List<StayImportResultDto>>().Result;
                Assert.AreEqual(1, res.Count);
                Assert.IsTrue(res[0].Success);
            }
        }

        [TestMethod]
        public void ReadDataFromOracleWithDapper()
        {
            Importer.Log = new StringBuilder();
            MockSettings settings = new MockSettings("OracleConnection");
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(settings.ConnectionString.ProviderName);
            var reservationsByHotel = new List<StayData>();

            using (var conn = dbFactory.CreateConnection())
            {
                conn.ConnectionString = settings.ConnectionString.ConnectionString;
                var reservationsList = conn.Query<StayData>(settings.QueryString);
                var map = reservationsList
                    .GroupBy(x => x.HotelId)
                    .ToDictionary(x => x.Key, x => x.ToList());
                foreach (var key in map.Keys)
                {
                    foreach (var reserv in map[(string) key])
                    {
                        if (string.IsNullOrWhiteSpace(reserv.ExternalKey) ||
                            reserv.PeriodStart.Equals(DateTimeOffset.MinValue) ||
                            reserv.PeriodEnd.Equals(DateTimeOffset.MinValue) ||
                            string.IsNullOrWhiteSpace(reserv.GuestEmail))
                        {
                            continue;
                        }
                        reserv.Reservation = reserv.Reservation ?? reserv.ExternalKey;
                        reservationsByHotel.Add(reserv);
                    }
                }
            }

            Assert.IsTrue(108 > reservationsByHotel.Count);
        }

        [TestMethod]
        public void ReadMappingsFile()
        {
            List<HotelMapping> l = new List<HotelMapping>();
            l.Add(new HotelMapping {HotelId = "1"});
            l.Add(new HotelMapping {HotelId = "2"});
            var json = JsonConvert.SerializeObject(l);

            var res = JsonConvert.DeserializeObject<List<HotelMapping>>(File.ReadAllText(@"..\..\..\HotelMappings.json"));
        }

        [TestMethod]
        public void FormatResult()
        {
            var g = Guid.Empty;
            //var r = string.Empty.ToString("00000000-0000-0000-0000-000000000000");

        }

        [TestMethod]
        public void ReadDataWithDapper()
        {
            Importer.Log = new StringBuilder();
            MockSettings settings = new MockSettings("OracleConnection");
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(settings.ConnectionString.ProviderName);

            using (var conn = dbFactory.CreateConnection())
            {
                conn.ConnectionString = settings.ConnectionString.ConnectionString;
                var reservationsList = conn.Query<StayData>(settings.QueryString);
                var map = reservationsList
                      .GroupBy(x => x.HotelId)
                      .ToDictionary(x => x.Key, x => x.ToList());
                foreach (var key in map.Keys)
                {
                    var reservationsByHotel = new List<StayData>();
                    foreach (var reserv in map[(string) key])
                    {
                        var baseUri = new Uri("https://bguest-integration-api-dev.azurewebsites.net/");
                        using (var client = new HttpClient {BaseAddress = baseUri})
                        {
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));

                            var apiKey = Guid.Parse("7aa3921f-d388-4015-9d23-f0ac3b919739");
                            var apiSecret = "lnGI6XpfLYNe3SdwWCLF-qcn_zm67qk_EcGRfL-1zt81";
                            var requestApiUrl = $"api/v2/stays?apiKey={apiKey}&apiSecret={apiSecret}";

                            var responseBGuest = client.PostAsJsonAsync(requestApiUrl, reservationsByHotel);
                            responseBGuest.Wait();
                            if (responseBGuest.Result.IsSuccessStatusCode)
                            {
                                var res = responseBGuest.Result.Content.ReadAsAsync<List<StayImportResultDto>>();
                                res.Wait();
                                foreach (var reservationResult in res.Result)
                                {
                                    System.Console.WriteLine(reservationResult.Success);
                                }
                            }
                            else
                            {
                                var exception = responseBGuest.Result.Content.ReadAsAsync<dynamic>().Result;
                                System.Console.WriteLine(exception.message);

                            }

                        }
                    }

                }
            }

            //Importer.ImportTemplate(dbFactory, settings);
            //SendMail.ResultLogAsync(Importer.Log.ToString());
        }

        [TestMethod]
        public void ReadManaged()
        {
            try
            {
                // Please replace the connection string attribute settings
                //string constr = "Data Source=XE;Persist Security Info=True;User Id=hr;Password=hr";
                string constr = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["OracleConnection"].ProviderName);
                var conn = dbFactory.CreateConnection();
                conn.ConnectionString = constr;
                conn.Open();
                System.Console.WriteLine("Connected to Oracle Database {0}", conn.ServerVersion);
                conn.Dispose();

                System.Console.WriteLine("Press RETURN to exit.");
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : {0}", ex);
                System.Console.ReadLine();
            }
        }
    }
}

public class MockSettings : ConfigFileFactory
{
    public MockSettings(string nameConnection)
    {
        ConnectionString = ConfigurationManager.ConnectionStrings[nameConnection];
    }

    public override ConnectionStringSettings ConnectionString { get; }


    public override string QueryString
    {
        get { return @"
                    SELECT  'VG-7aa3921f-d388-4015-9d23-f0ac3b919739' hotelId
                            --null room 
                            --, Round(dbms_random.value * 5)  reservation
                            ,periodStart 
                            ,periodEnd
                            ,cast(0 as number(1)) isCheckedIn
                            --,cast(0 as number(1)) allowExpressCheckout
                            --,null currentBillValue  
                            --,null currentBillDate
                            --,null currentBillCurrency
                            --,cast(0 as number(1)) isBreakfastIncluded
                            ,'debugtest' || guestEmail guestEmail
                            ,guestFirstName
                            ,guestLastName 
                            ,guestPhoneNumber
                            ,to_char(rownum) externalKey
                            --,state
                       FROM reservations";
        }
    }
}

