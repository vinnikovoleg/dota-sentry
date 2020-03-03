using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DotaSentry.Models.SteamClient;

namespace DotaSentry.Business.SteamClient.DataAccess
{
    public class SteamFileRepository : DotaSentry.Business.SteamClient.DataAccess.SteamBaseRepository
    {
        public SteamFileRepository(DotaSentry.Business.SteamClient.DataAccess.JsonClient jsonClient) : base(jsonClient)
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
