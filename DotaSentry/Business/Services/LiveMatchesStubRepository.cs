using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DotaSentry.SteamClient.Business.DataAccess;
using DotaSentry.SteamClient.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace DotaSentry.Business.Services
{
    public class LiveMatchesStubRepository : IMatchesRepository    
    {
        private readonly string _getTopLiveMatches = "StaticFiles/Data/GetTopLiveGame.json";
        private readonly string _getRealtimeStats = "StaticFiles/Data/GetRealtimeStats.json";
        private readonly IWebHostEnvironment _environment;

        public LiveMatchesStubRepository(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        public async Task<GetTopLiveGamesResponse> GetTopLiveMatchesAsync(int partnerId = 0)
        {
            var dataPath = Path.Combine(_environment.WebRootPath, _getTopLiveMatches);

            if (!File.Exists(dataPath))
            {
                return new GetTopLiveGamesResponse();
            }

            var json = await File.ReadAllTextAsync(dataPath);
            return JsonConvert.DeserializeObject<GetTopLiveGamesResponse>(json);
        }

        public async Task<GetRealtimeMatchStatsResponse> GetRealtimeMatchStatsAsync(ulong serverSteamId)
        {
            var dataPath = Path.Combine(_environment.WebRootPath, _getRealtimeStats);

            if (!File.Exists(dataPath))
            {
                return new GetRealtimeMatchStatsResponse();
            }

            var json = await File.ReadAllTextAsync(dataPath);
            return JsonConvert.DeserializeObject<GetRealtimeMatchStatsResponse>(json);
        }
    }
}