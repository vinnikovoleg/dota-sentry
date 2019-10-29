using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class PicksBan
    {
        [JsonProperty("is_pick")]
        public bool IsPick { get; set; }

        [JsonProperty("hero_id")]
        public long HeroId { get; set; }

        [JsonProperty("team")]
        public long Team { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }

        [JsonProperty("ord")]
        public long Ord { get; set; }

        [JsonProperty("match_id")]
        public long MatchId { get; set; }
    }
}
