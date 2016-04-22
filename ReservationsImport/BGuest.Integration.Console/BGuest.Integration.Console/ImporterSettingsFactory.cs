using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace BGuest.Integration.Console
{
    public static class ImporterSettingsFactories
    {
        public static ImporterSettingsFactory GetFactory(string settingsProvider)
        {
            switch (settingsProvider)
            {
                case "File":
                default :
                    return new ConfigFileFactory();
            }
        }
    }

    public abstract class ImporterSettingsFactory
    {
        public abstract string HotelDescription { get; }
        public abstract ConnectionStringSettings ConnectionString { get; }
        public abstract string BaseUri { get; }
        public abstract string QueryString { get; }

        public abstract HotelMapping HotelMapping(string hotelId);

        public abstract List<HotelMapping> HotelMappings { get; }
    }

    public class HotelMapping
    {
        public string HotelDescription { get; set; }
        public string HotelId { get; set; }
        public Guid ApiKey { get; set; }
        public string ApiSecret { get; set; }

    }

    public class ConfigFileFactory : ImporterSettingsFactory
    {
        public ConfigFileFactory()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"];
            ConnectionString = connectionString;
            QueryString = ConfigurationManager.AppSettings["queryString"];
            BaseUri = ConfigurationManager.AppSettings["apiBaseUri"];
            HotelMappings = JsonConvert.DeserializeObject<List<HotelMapping>>(File.ReadAllText(@"HotelMappings.json"));
            HotelDescription = ConfigurationManager.AppSettings["hotelDescription"];
        }
        public override string BaseUri { get; }

        public override string HotelDescription { get; }

        public override ConnectionStringSettings ConnectionString { get; }

        public override string QueryString { get; }

        public override HotelMapping HotelMapping(string hotelId)
        {
            return HotelMappings.Find(m => m.HotelId == hotelId);
        }

        public override List<HotelMapping> HotelMappings { get; }
    }
}