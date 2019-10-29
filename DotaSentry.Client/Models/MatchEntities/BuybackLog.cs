using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class BuybackLog
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("player_slot")]
        public long PlayerSlot { get; set; }
    }
}
