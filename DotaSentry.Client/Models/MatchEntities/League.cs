using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class League
    {
        [JsonProperty("leagueid")]
        public long LeagueId { get; set; }

        [JsonProperty("ticket")]
        public object Ticket { get; set; }

        [JsonProperty("banner")]
        public object Banner { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
