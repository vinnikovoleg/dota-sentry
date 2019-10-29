using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class KillsLogElement
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }

}
