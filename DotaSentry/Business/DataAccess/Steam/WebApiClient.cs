using System.Threading.Tasks;
using DotaSentry.Business.DataAccess.Json;
using DotaSentry.Business.DataAccess.Steam.Models;

namespace DotaSentry.Business.DataAccess.Steam
{
    public class WebApiClient
    {
        private readonly JsonClient _jsonClient;

        public WebApiClient(JsonClient jsonClient)
        {
            _jsonClient = jsonClient;
        }

        public async Task<SteamLeagueListResponse> GetLeaguesAsync()
        {
            return await _jsonClient.GetAsync<SteamLeagueListResponse>(
                "https://www.dota2.com/webapi/IDOTA2League/GetLeagueInfoList/v0001/?");
        }
    }
}