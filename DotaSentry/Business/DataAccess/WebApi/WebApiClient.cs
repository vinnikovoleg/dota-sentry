using System.Net.Http;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess.Json;

// namespace DotaSentry.Business.DataAccess.WebApi
// {
//     public class WebApiClient
//     {
//         private readonly JsonClient _jsonClient;
//
//         public WebApiClient(JsonClient jsonClient)
//         {
//             _jsonClient = jsonClient;
//         }
//
//         public async Task<GetLiveGamesResponse> GetLiveGamesAsync()
//         {
//             return await _jsonClient.GetAsync<GetLiveGamesResponse>(
//                 "https://www.dota2.com/webapi/IDOTA2League/GetLiveGames/v0001/?");
//         }
//     }
// }