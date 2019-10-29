using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class MaxHeroHit
    {
        [JsonProperty("type")]
        public MaxHeroHitType Type { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("max")]
        public bool Max { get; set; }

        [JsonProperty("inflictor")]
        public string Inflictor { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }

        [JsonProperty("player_slot")]
        public long PlayerSlot { get; set; }
    }

}
