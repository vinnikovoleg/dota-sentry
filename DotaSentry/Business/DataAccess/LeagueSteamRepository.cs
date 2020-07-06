using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess.Json;
using DotaSentry.Business.DataAccess.Steam;
using DotaSentry.Business.DataAccess.Steam.Models;
using DotaSentry.Models;
using Microsoft.Extensions.Caching.Memory;
using League = DotaSentry.Models.League;

namespace DotaSentry.Business.DataAccess
{
    public class LeagueRepository
    {
        private readonly WebApiClient _webApiClient;
        private readonly IMemoryCache _memoryCache;

        public LeagueRepository(
            WebApiClient webApiClient,
            IMemoryCache memoryCache)
        {
            _webApiClient = webApiClient;
            _memoryCache = memoryCache;
        }

        public async Task<List<League>> GetLeaguesAsync()
        {
            const string cacheKey = "laegues_cache";
            return await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
                var leagueListResponse = await _webApiClient.GetLeaguesAsync();
                return leagueListResponse.Leagues != null
                    ? leagueListResponse.Leagues
                        .Select(Build)
                        .Where(l => l.StartTimestamp < DateTime.Now && l.EndTimestamp > DateTime.Now && l.Tier > 1)
                        .ToList()
                    : new List<League>();
            });
        }

        public async Task<League> GetAsync(long id)
        {
            var leagues = await GetLeaguesAsync();
            return leagues.FirstOrDefault(l => l.Id == id);
        }

        private League Build(SteamLeague steamLeague)
        {
            return new League
            {
                Id = steamLeague.LeagueId,
                Name = steamLeague.Name,
                Region = steamLeague.Region,
                Status = steamLeague.Status,
                Tier = steamLeague.Tier,
                MostRecentActivity = DateTimeOffset.FromUnixTimeSeconds(steamLeague.MostRecentActivity).DateTime,
                StartTimestamp = DateTimeOffset.FromUnixTimeSeconds(steamLeague.StartTimestamp).DateTime,
                EndTimestamp = DateTimeOffset.FromUnixTimeSeconds(steamLeague.EndTimestamp).DateTime,
                TotalPrizePool = steamLeague.TotalPrizePool
            };
        }
    }
}