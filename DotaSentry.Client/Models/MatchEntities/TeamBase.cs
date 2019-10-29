using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.Client.Models.MatchEntities
{
    public class TeamBase
    {
        [JsonProperty("team_id")]
        public long TeamId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("logo_url")]
        public Uri LogoUrl { get; set; }
    }
}
