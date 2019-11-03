using System.Collections.Generic;
using System.Threading.Tasks;
using DotaSentry.SteamClient.Models;

namespace DotaSentry.SteamClient.Business.DataAccess
{
    public class MatchesRepository : SteamBaseRepository
    {
        public MatchesRepository(JsonClient jsonClient) : base(jsonClient)
        {
        }

        public async Task<GetTopLiveGamesResponse> GetTopLiveMatchesAsync(int partnerId = 0)
        {
            var parameters = new Dictionary<string, string> { { "partner", partnerId.ToString() } };
            var requestUrl = GetRequestUrl("IDOTA2Match_570", "GetTopLiveGame", parameters);
            return await JsonClient.GetAsync<GetTopLiveGamesResponse>(requestUrl);
        }
    }
}
