using System.Collections.Generic;
using System.Threading.Tasks;
using DotaSentry.SteamClient.Models;

namespace DotaSentry.SteamClient.Business.DataAccess
{
    public class HeroesRepository : SteamBaseRepository
    {
        public HeroesRepository(JsonClient jsonClient) : base(jsonClient)
        {
        }

        public async Task<GetHeroesResponse> GetHeroesAsync()
        {
            var parameters = new Dictionary<string, string> { { "language", "en" } };
            var requestUrl = GetRequestUrl("IEconDOTA2_570", "GetHeroes", parameters);
            return await JsonClient.GetAsync<GetHeroesResponse>(requestUrl);
        }
    }
}
