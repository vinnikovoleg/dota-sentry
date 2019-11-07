using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DotaSentry.SteamClient.Models
{
    public class GetRealtimeMatchStatsResponse
    {
        [JsonProperty("match")]
        public RealtimeMatch Match { get; set; }

        [JsonProperty("teams")]
        public List<RealtimeTeam> Teams { get; set; }

        [JsonProperty("buildings")]
        public List<Building> Buildings { get; set; }

        [JsonProperty("graph_data")]
        public GraphData GraphData { get; set; }

        [JsonProperty("delta_frame")]
        public bool DeltaFrame { get; set; }
    }

    public class Building
    {
        [JsonProperty("team")]
        public long Team { get; set; }

        [JsonProperty("heading")]
        public double Heading { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("lane")]
        public long Lane { get; set; }

        [JsonProperty("tier")]
        public long Tier { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("destroyed")]
        public bool Destroyed { get; set; }
    }

    public class GraphData
    {
        [JsonProperty("graph_gold")]
        public List<long> GraphGold { get; set; }
    }

    public class RealtimeMatch
    {
        [JsonProperty("server_steam_id")]
        public double ServerSteamId { get; set; }

        [JsonProperty("matchid")]
        public long MatchId { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("game_time")]
        public long GameTime { get; set; }

        [JsonProperty("game_mode")]
        public long GameMode { get; set; }

        [JsonProperty("league_id")]
        public long LeagueId { get; set; }

        [JsonProperty("league_node_id")]
        public long LeagueNodeId { get; set; }

        [JsonProperty("game_state")]
        public long GameState { get; set; }

        [JsonProperty("picks")]
        public List<Ban> Picks { get; set; }

        [JsonProperty("bans")]
        public List<Ban> Bans { get; set; }
    }

    public class Ban
    {
        [JsonProperty("hero")]
        public long Hero { get; set; }

        [JsonProperty("team")]
        public long Team { get; set; }
    }

    public class RealtimeTeam
    {
        [JsonProperty("team_number")]
        public long TeamNumber { get; set; }

        [JsonProperty("team_id")]
        public long TeamId { get; set; }

        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        [JsonProperty("team_tag")]
        public string TeamTag { get; set; }

        [JsonProperty("team_logo")]
        public double TeamLogo { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("net_worth")]
        public long NetWorth { get; set; }

        [JsonProperty("team_logo_url")]
        public Uri TeamLogoUrl { get; set; }

        [JsonProperty("players")]
        public List<RealtimePlayer> Players { get; set; }
    }

    public class RealtimePlayer
    {
        [JsonProperty("accountid")]
        public long Accountid { get; set; }

        [JsonProperty("playerid")]
        public long Playerid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("team")]
        public long Team { get; set; }

        [JsonProperty("heroid")]
        public long Heroid { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("kill_count")]
        public long KillCount { get; set; }

        [JsonProperty("death_count")]
        public long DeathCount { get; set; }

        [JsonProperty("assists_count")]
        public long AssistsCount { get; set; }

        [JsonProperty("denies_count")]
        public long DeniesCount { get; set; }

        [JsonProperty("lh_count")]
        public long LhCount { get; set; }

        [JsonProperty("gold")]
        public long Gold { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("net_worth")]
        public long NetWorth { get; set; }

        [JsonProperty("abilities")]
        public List<long> Abilities { get; set; }

        [JsonProperty("items")]
        public List<long> Items { get; set; }
    }
}
