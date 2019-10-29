using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class DraftTiming
    {
        [JsonProperty("order")]
        public long Order { get; set; }

        [JsonProperty("pick")]
        public bool Pick { get; set; }

        [JsonProperty("active_team")]
        public long ActiveTeam { get; set; }

        [JsonProperty("hero_id")]
        public long HeroId { get; set; }

        [JsonProperty("player_slot")]
        public long? PlayerSlot { get; set; }

        [JsonProperty("extra_time")]
        public long ExtraTime { get; set; }

        [JsonProperty("total_time_taken")]
        public long TotalTimeTaken { get; set; }
    }
}
