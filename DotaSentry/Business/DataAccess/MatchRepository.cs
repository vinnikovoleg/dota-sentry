using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.Builders;
using DotaSentry.Business.DataAccess.SteamClient;
using DotaSentry.Models;
using DotaSentry.Models.SteamClient;

namespace DotaSentry.Business.DataAccess
{
    public class MatchRepository
    {
        private readonly SteamDotaClient _steamDotaClient;
        private readonly LiveMatchBuilder _liveMatchBuilder;
        private readonly MatchStatsBuilder _matchStatsBuilder;

        public MatchRepository(
            SteamDotaClient steamDotaClient,
            LiveMatchBuilder liveMatchBuilder,
            MatchStatsBuilder matchStatsBuilder)
        {
            _steamDotaClient = steamDotaClient;
            _liveMatchBuilder = liveMatchBuilder;
            _matchStatsBuilder = matchStatsBuilder;
        }

        public async Task<List<LiveMatchModel>> GetLiveAsync(int partnerId = 0)
        {
            var response = await _steamDotaClient.GetTopLiveMatchesAsync(partnerId);
            var liveMatches = response.GameList;
            var matchModels = new List<LiveMatchModel>();
            foreach (var liveMatch in liveMatches.Where(g =>
                    !string.IsNullOrEmpty(g.TeamNameDire)
                    && !string.IsNullOrEmpty(g.TeamNameRadiant))
                .Distinct(new MatchComparer()))
            {
                var matchModel = await _liveMatchBuilder.Build(liveMatch);
                matchModels.Add(matchModel);
            }

            return matchModels;
        }

        public async Task<LiveMatchStatsModel> GetLiveStatsAsync(ulong serverSteamId)
        {
            var matchStats = await _steamDotaClient.GetRealtimeMatchStatsAsync(serverSteamId);
            return await _matchStatsBuilder.Build(matchStats);
        }

        public class MatchComparer : IEqualityComparer<LiveMatch>
        {
            public bool Equals(LiveMatch x, LiveMatch y)
            {
                if (x == null || y == null)
                {
                    return false;
                }

                return x.MatchId == y.MatchId;
            }

            public int GetHashCode(LiveMatch obj)
            {
                return obj.MatchId.GetHashCode();
            }
        }
    }
}