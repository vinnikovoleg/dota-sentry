using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess.Json;
using DotaSentry.Business.DataAccess.WebApi;
using DotaSentry.Business.DataAccess.WebApi.Models;
using DotaSentry.Models;
using Microsoft.Extensions.Caching.Memory;

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

        public async Task<List<LeagueModel>> GetLeaguesAsync()
        {
            const string cacheKey = "laegues_cache";
            return await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
                var leagueListResponse = await _webApiClient.GetLeaguesAsync();
                return leagueListResponse.Leagues != null
                    ? leagueListResponse.Leagues
                        .Select(Build)
                        .Where(l => l.StartTimestamp < DateTime.Now && l.EndTimestamp > DateTime.Now)
                        .ToList()
                    : new List<LeagueModel>();
            });
        }

        public async Task<LeagueModel> GetAsync(long id)
        {
            var leagues = await GetLeaguesAsync();
            return leagues.FirstOrDefault(l => l.Id == id);
        }

        private LeagueModel Build(League league)
        {
            return new LeagueModel
            {
                Id = league.LeagueId,
                Name = league.Name,
                Region = league.Region,
                Status = league.Status,
                Tier = league.Tier,
                MostRecentActivity = DateTimeOffset.FromUnixTimeSeconds(league.MostRecentActivity).DateTime,
                StartTimestamp = DateTimeOffset.FromUnixTimeSeconds(league.StartTimestamp).DateTime,
                EndTimestamp = DateTimeOffset.FromUnixTimeSeconds(league.EndTimestamp).DateTime,
                TotalPrizePool = league.TotalPrizePool
            };
        }
    }
}