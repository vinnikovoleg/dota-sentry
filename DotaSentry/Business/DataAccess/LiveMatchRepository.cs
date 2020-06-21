using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.Builders;
using DotaSentry.Business.DataAccess.Steam;
using DotaSentry.Models;

namespace DotaSentry.Business.DataAccess
{
    public class LiveMatchRepository
    {
        private readonly SteamDotaClient _steamDotaClient;
        private readonly LiveMatchBuilder _liveMatchBuilder;
        private readonly LeagueRepository _leagueRepository;

        public LiveMatchRepository(
            SteamDotaClient steamDotaClient,
            LiveMatchBuilder liveMatchBuilder,
            LeagueRepository leagueRepository)
        {
            _steamDotaClient = steamDotaClient;
            _liveMatchBuilder = liveMatchBuilder;
            _leagueRepository = leagueRepository;
        }

        public async Task<List<LiveMatch>> GetAsync(int partnerId = 0)
        {
            var response = await _steamDotaClient.GetTopLiveMatchesAsync(partnerId);
            var liveMatches = response.GameList;
            var matchModels = new List<LiveMatch>();
            foreach (var liveMatch in liveMatches.Where(g =>
                !string.IsNullOrEmpty(g.TeamNameDire)
                && !string.IsNullOrEmpty(g.TeamNameRadiant)))
            {
                var league = await _leagueRepository.GetAsync(liveMatch.LeagueId);
                var matchModel = await _liveMatchBuilder.Build(liveMatch, league);
                matchModels.Add(matchModel);
            }

            return matchModels;
        }
    }
}