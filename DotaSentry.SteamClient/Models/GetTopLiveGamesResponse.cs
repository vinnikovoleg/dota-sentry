using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotaSentry.SteamClient.Models
{
    public class GetTopLiveGamesResponse
    {
        [JsonProperty("game_list")]
        public List<LiveMatch> GameList { get; set; }
    }

    public class LiveMatch
    {
        [JsonProperty("activate_time")]
        public long ActivateTime { get; set; }

        [JsonProperty("deactivate_time")]
        public long DeactivateTime { get; set; }

        [JsonProperty("server_steam_id")]
        public double ServerSteamId { get; set; }

        [JsonProperty("lobby_id")]
        public double LobbyId { get; set; }

        [JsonProperty("league_id")]
        public long LeagueId { get; set; }

        [JsonProperty("lobby_type")]
        public long LobbyType { get; set; }

        [JsonProperty("game_time")]
        public long GameTime { get; set; }

        [JsonProperty("delay")]
        public long Delay { get; set; }

        [JsonProperty("spectators")]
        public long Spectators { get; set; }

        [JsonProperty("game_mode")]
        public long GameMode { get; set; }

        [JsonProperty("average_mmr")]
        public long AverageMmr { get; set; }

        [JsonProperty("match_id")]
        public long MatchId { get; set; }

        [JsonProperty("series_id")]
        public long SeriesId { get; set; }

        [JsonProperty("sort_score")]
        public long SortScore { get; set; }

        [JsonProperty("last_update_time")]
        public long LastUpdateTime { get; set; }

        [JsonProperty("radiant_lead")]
        public long RadiantLead { get; set; }

        [JsonProperty("radiant_score")]
        public long RadiantScore { get; set; }

        [JsonProperty("dire_score")]
        public long DireScore { get; set; }

        [JsonProperty("players")]
        public List<Player1> Players { get; set; }

        [JsonProperty("building_state")]
        public long BuildingState { get; set; }

        [JsonProperty("team_name_radiant", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamNameRadiant { get; set; }

        [JsonProperty("team_name_dire", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamNameDire { get; set; }

        [JsonProperty("team_logo_radiant", NullValueHandling = NullValueHandling.Ignore)]
        public long? TeamLogoRadiant { get; set; }

        [JsonProperty("team_logo_dire", NullValueHandling = NullValueHandling.Ignore)]
        public long? TeamLogoDire { get; set; }

        [JsonProperty("team_id_radiant", NullValueHandling = NullValueHandling.Ignore)]
        public long? TeamIdRadiant { get; set; }

        [JsonProperty("team_id_dire", NullValueHandling = NullValueHandling.Ignore)]
        public long? TeamIdDire { get; set; }
    }

    public class Player1
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("hero_id")]
        public long HeroId { get; set; }
    }
}
