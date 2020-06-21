using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.Builders;
using DotaSentry.Business.DataAccess.Steam;
using DotaSentry.Models;

namespace DotaSentry.Business.DataAccess
{
    public class MatchStatsRepository
    {
        private readonly SteamDotaClient _steamDotaClient;
        private readonly MatchStatsBuilder _matchStatsBuilder;

        public MatchStatsRepository(
            SteamDotaClient steamDotaClient,
            MatchStatsBuilder matchStatsBuilder)
        {
            _steamDotaClient = steamDotaClient;
            _matchStatsBuilder = matchStatsBuilder;
        }

        public async Task<MatchStats> GetAsync(ulong serverSteamId)
        {
            var matchStats = await _steamDotaClient.GetRealtimeMatchStatsAsync(serverSteamId);
            return await _matchStatsBuilder.Build(matchStats);
        }
    }
}