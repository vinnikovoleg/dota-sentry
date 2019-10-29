using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotaSentry.Client.Models
{
    public class LiveMatch
    {
        [JsonProperty("activate_time")]
        public long ActivateTime { get; set; }

        [JsonProperty("deactivate_time")]
        public long DeactivateTime { get; set; }

        [JsonProperty("server_steam_id")]
        public long ServerSteamId { get; set; }

        [JsonProperty("lobby_id")]
        public long LobbyId { get; set; }

        [JsonProperty("league_id")]
        public long LeagueId { get; set; }
    }
}
