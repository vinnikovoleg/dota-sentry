using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Models;
using DotaSentry.SteamClient.Business.DataAccess;
using DotaSentry.SteamClient.Models;

namespace DotaSentry.Business.Services
{
    public class LiveMatchesService
    {
        private readonly IMatchesRepository _matchesRepository;
        private readonly ImageService _imageService;

        public LiveMatchesService(
            IMatchesRepository matchesRepository,
            ImageService imageService)
        {
            _matchesRepository = matchesRepository;
            _imageService = imageService;
        }

        public async Task<List<LiveMatchModel>> GetLiveMatchesAsync()
        {
            var liveMatches = await _matchesRepository.GetTopLiveMatchesAsync();
            var matchModels = new List<LiveMatchModel>();
            foreach (var liveMatch in liveMatches.GameList)
            {
                var matchModel = await BuildLiveMatchModel(liveMatch);
                matchModels.Add(matchModel);
            }

            return matchModels;
        }

        public async Task<GetRealtimeMatchStatsResponse> GetRealtimeMatchStatsAsync(ulong serverSteamId)
        {
            return await _matchesRepository.GetRealtimeMatchStatsAsync(serverSteamId);
        }

        private async Task<LiveMatchModel> BuildLiveMatchModel(LiveMatch match)
        {
            return new LiveMatchModel
            {
                MatchId = match.MatchId,
                ServerSteamId = match.ServerSteamId,
                GameTime = TimeSpan.FromSeconds(match.GameTime),
                Radiant = new TeamModel
                {
                    Name = match.TeamNameRadiant,
                    Lead = match.RadiantLead > 0 ? match.RadiantLead : 0,
                    Score = match.RadiantScore,
                    Logo = match.TeamLogoRadiant.HasValue ? await _imageService.GetSteamImageUrlAsync(match.TeamLogoRadiant.Value) : string.Empty
                },
                Dire = new TeamModel
                {
                    Name = match.TeamNameDire,
                    Lead = match.RadiantLead < 0 ? Math.Abs(match.RadiantLead) : 0,
                    Score = match.DireScore,
                    Logo = match.TeamLogoDire.HasValue ? await _imageService.GetSteamImageUrlAsync(match.TeamLogoDire.Value) : string.Empty
                }
            };
        }
    }
}
