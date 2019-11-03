using System.Collections.Generic;
using System.Linq;

namespace DotaSentry.SteamClient.Business.DataAccess
{
    public abstract class SteamBaseRepository
    {
        protected readonly JsonClient JsonClient;
        private readonly string _host = "https://api.steampowered.com";
        private readonly string _version = "v1";
        private readonly string _apiKey = "0B49CEB49A52EF5593677EAD8F31AFD2";

        protected SteamBaseRepository(JsonClient jsonClient)
        {
            JsonClient = jsonClient;
        }

        protected string GetRequestUrl(string interfaceName, string methodName, Dictionary<string, string> parameters = null)
        {
            var queryParams = parameters != null && parameters.Any() ? $"&{string.Join("&", parameters.Select(pair => $"{pair.Key}={pair.Value}"))}" : string.Empty;
            return $"{_host}/{interfaceName}/{methodName}/{_version}?key={_apiKey}{queryParams}";
        }
    }
}
