using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BGuest.Integration.Console.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StayStates
    {
        Removed = -1,
        Active = 0,
    }
}