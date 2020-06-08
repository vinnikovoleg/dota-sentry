using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess.Json;
using DotaSentry.Models.SteamClient;

namespace DotaSentry.Business.DataAccess.SteamClient
{
    public class SteamDotaClient : SteamBaseClient
    {
        public SteamDotaClient(JsonClient jsonClient) : base(jsonClient)
        {
        }

        public async Task<GetTopLiveGamesResponse> GetTopLiveMatchesAsync(int partnerId)
        {
            var parameters = new Dictionary<string, string> { { "partner", partnerId.ToString() } };
            var requestUrl = GetRequestUrl("IDOTA2Match_570", "GetTopLiveGame", parameters);
            return await JsonClient.GetAsync<GetTopLiveGamesResponse>(requestUrl);
        }

        public async Task<GetRealtimeMatchStatsResponse> GetRealtimeMatchStatsAsync(ulong serverSteamId)
        {
            var parameters = new Dictionary<string, string> { { "server_steam_id", serverSteamId.ToString(CultureInfo.InvariantCulture) } };
            var requestUrl = GetRequestUrl("IDOTA2MatchStats_570", "GetRealtimeStats", parameters);
            return await JsonClient.GetAsync<GetRealtimeMatchStatsResponse>(requestUrl);
        }

        // public async Task<GetLiveLeagueGamesResponse> GetLiveLeagueGamesAsync()
        // {
        //     var requestUrl = GetRequestUrl("IDOTA2Match_570", "GetLiveLeagueGames");
        //     return await JsonClient.GetAsync<GetLiveLeagueGamesResponse>(requestUrl);
        // }
    }
}
