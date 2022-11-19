using Newtonsoft.Json;

namespace DataProvider.Backend.DataObjects
{
    public class TrackNumber
    {
        [JsonProperty("track")]
        public string Track { get; set; }
    }
}