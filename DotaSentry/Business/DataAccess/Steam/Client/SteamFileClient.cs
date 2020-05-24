using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DotaSentry.Models.SteamClient;

namespace DotaSentry.Business.DataAccess.Steam.Client
{
    public class SteamFileClient : SteamBaseClient
    {
        public SteamFileClient(JsonClient jsonClient) : base(jsonClient)
        {
        }

        public async Task<GetSteamFileResponse> GetLogoInfoAsync(long id)
        {
            var parameters = new Dictionary<string, string>
            {
                { "ugcid", id.ToString(CultureInfo.InvariantCulture) } ,
                { "appid", "570" }
            };
            var requestUrl = GetRequestUrl("ISteamRemoteStorage", "GetUGCFileDetails", parameters);
            return await JsonClient.GetAsync<GetSteamFileResponse>(requestUrl);
        }
    }
}
