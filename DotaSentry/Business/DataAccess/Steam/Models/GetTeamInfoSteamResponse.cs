using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotaSentry.Business.DataAccess.Steam.Models
{
    public class GetTeamInfoSteamResponse
    {
        [JsonProperty("result")]
        public SteamTeamInfoResult Result { get; set; }
    }

    public class SteamTeamInfoResult
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("teams")]
        public List<SteamTeamInfo> Teams { get; set; }
    }

    public class SteamTeamInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("time_created")]
        public long TimeCreated { get; set; }

        [JsonProperty("logo")]
        public double Logo { get; set; }

        [JsonProperty("logo_sponsor")]
        public double LogoSponsor { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("games_played")]
        public long GamesPlayed { get; set; }

        [JsonProperty("player_0_account_id")]
        public long Player0_AccountId { get; set; }

        [JsonProperty("player_1_account_id")]
        public long Player1_AccountId { get; set; }

        [JsonProperty("player_2_account_id")]
        public long Player2_AccountId { get; set; }

        [JsonProperty("player_3_account_id")]
        public long Player3_AccountId { get; set; }

        [JsonProperty("admin_account_id")]
        public long AdminAccountId { get; set; }
    }
}
