using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using DotaSentry.SteamClient.Models;

namespace DotaSentry.SteamClient.Business.DataAccess
{
    public class SteamFileRepository : SteamBaseRepository
    {
        public SteamFileRepository(JsonClient jsonClient) : base(jsonClient)
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
