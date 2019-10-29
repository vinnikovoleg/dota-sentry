using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class Objective
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("type")]
        public ObjectiveType Type { get; set; }

        [JsonProperty("slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? Slot { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public Key? Key { get; set; }

        [JsonProperty("player_slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayerSlot { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("team", NullValueHandling = NullValueHandling.Ignore)]
        public long? Team { get; set; }
    }
}
