using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class RunesLog
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("key")]
        public long Key { get; set; }
    }
}
