using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotaSentry.SteamClient.Models
{
    public class GetMatchesHistoryResponse
    {
        [JsonProperty("result")]
        public Result1 Result { get; set; }
    }

    public class Result1
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("num_results")]
        public long NumResults { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }

        [JsonProperty("results_remaining")]
        public long ResultsRemaining { get; set; }

        [JsonProperty("matches")]
        public List<Match> Matches { get; set; }
    }

    public class Match
    {
        [JsonProperty("match_id")]
        public long MatchId { get; set; }

        [JsonProperty("match_seq_num")]
        public long MatchSeqNum { get; set; }

        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        [JsonProperty("lobby_type")]
        public long LobbyType { get; set; }

        [JsonProperty("radiant_team_id")]
        public long RadiantTeamId { get; set; }

        [JsonProperty("dire_team_id")]
        public long DireTeamId { get; set; }

        [JsonProperty("players")]
        public List<Player> Players { get; set; }
    }

    public class Player
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("player_slot")]
        public long PlayerSlot { get; set; }

        [JsonProperty("hero_id")]
        public long HeroId { get; set; }
    }
}
