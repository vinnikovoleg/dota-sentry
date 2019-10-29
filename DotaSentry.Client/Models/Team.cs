using System;
using System.Collections.Generic;
using System.Text;
using DotaSentry.Client.Models.MatchEntities;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models
{
    public class Team : TeamBase
    {
        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("last_match_time")]
        public long LastMatchTime { get; set; }
    }
}
