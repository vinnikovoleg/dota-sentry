﻿using Newtonsoft.Json;

namespace DotaSentry.Business.DataAccess.WebApi.Models
{
    public class League
    {
        [JsonProperty("league_id")]
        public long LeagueId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tier")]
        public long Tier { get; set; }

        [JsonProperty("region")]
        public long Region { get; set; }

        [JsonProperty("most_recent_activity")]
        public long MostRecentActivity { get; set; }

        [JsonProperty("total_prize_pool")]
        public long TotalPrizePool { get; set; }

        [JsonProperty("start_timestamp")]
        public long StartTimestamp { get; set; }

        [JsonProperty("end_timestamp")]
        public long EndTimestamp { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }
    }
}