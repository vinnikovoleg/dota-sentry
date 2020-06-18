using System.Net.Http;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess.Json;
using DotaSentry.Business.DataAccess.WebApi.Models;

namespace DotaSentry.Business.DataAccess.WebApi
{
    public class WebApiClient
    {
        private readonly JsonClient _jsonClient;

        public WebApiClient(JsonClient jsonClient)
        {
            _jsonClient = jsonClient;
        }

        public async Task<LeagueListResponse> GetLeaguesAsync()
        {
            return await _jsonClient.GetAsync<LeagueListResponse>(
                "https://www.dota2.com/webapi/IDOTA2League/GetLeagueInfoList/v0001/?");
        }
    }
}