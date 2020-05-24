using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DotaSentry.Business.DataAccess
{
    public class JsonClient
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public JsonClient(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            }; ;
        }

        public async Task<T> GetAsync<T>(string url) where T : class
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }

        public async void Post<T>(string url, T data) where T : class
        {
            var json = JsonConvert.SerializeObject(data, _jsonSerializerSettings);
            using var httpClient = new HttpClient();
            await httpClient.PostAsync(url, new StringContent(json));
        }
    }
}
