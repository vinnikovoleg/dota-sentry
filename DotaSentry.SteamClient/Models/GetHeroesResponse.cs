using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotaSentry.SteamClient.Models
{
    public class GetHeroesResponse
    {
        [JsonProperty("result")]
        public Result2 Result { get; set; }
    }

    public class Result2
    {
        [JsonProperty("heroes")]
        public List<Hero> Heroes { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public class Hero
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }
    }
}
