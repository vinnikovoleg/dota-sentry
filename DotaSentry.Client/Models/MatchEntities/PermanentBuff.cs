using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class PermanentBuff
    {
        [JsonProperty("permanent_buff")]
        public long PermanentBuffPermanentBuff { get; set; }

        [JsonProperty("stack_count")]
        public long StackCount { get; set; }
    }
}
