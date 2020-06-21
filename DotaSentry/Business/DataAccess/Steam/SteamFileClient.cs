using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess.Json;
using DotaSentry.Business.DataAccess.Steam.Models;

namespace DotaSentry.Business.DataAccess.Steam
{
    public class SteamFileClient : SteamBaseClient
    {
        public SteamFileClient(JsonClient jsonClient) : base(jsonClient)
        {
        }

        public async Task<GetFileSteamResponse> GetLogoInfoAsync(long id)
        {
            var parameters = new Dictionary<string, string>
            {
                { "ugcid", id.ToString(CultureInfo.InvariantCulture) } ,
                { "appid", "570" }
            };
            var requestUrl = GetRequestUrl("ISteamRemoteStorage", "GetUGCFileDetails", parameters);
            return await JsonClient.GetAsync<GetFileSteamResponse>(requestUrl);
        }
    }
}
