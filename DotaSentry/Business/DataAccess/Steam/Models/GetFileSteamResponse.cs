using System;
using Newtonsoft.Json;

namespace DotaSentry.Business.DataAccess.Steam.Models
{
    public class GetFileSteamResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }
    }
}
