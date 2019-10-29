using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class Chat
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("type")]
        public ChatType Type { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }

        [JsonProperty("player_slot")]
        public long PlayerSlot { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }
    }

}
