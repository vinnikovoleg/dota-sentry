using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class ObsLeftLogElement
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("type")]
        public ObsLeftLogType Type { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }

        [JsonProperty("attackername", NullValueHandling = NullValueHandling.Ignore)]
        public string AttackerName { get; set; }

        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("z")]
        public long Z { get; set; }

        [JsonProperty("entityleft")]
        public bool EntityLeft { get; set; }

        [JsonProperty("ehandle")]
        public long Ehandle { get; set; }

        [JsonProperty("player_slot")]
        public long PlayerSlot { get; set; }
    }
}
