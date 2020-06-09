using System;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess;
using DotaSentry.Models;
using DotaSentry.Models.SteamClient;

namespace DotaSentry.Business.Builders
{
    public class LiveMatchBuilder
    {
        private readonly ImageRepository _imageRepository;

        public LiveMatchBuilder(ImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<LiveMatchModel> Build(LiveMatch match)
        {
            return new LiveMatchModel
            {
                MatchId = match.MatchId,
                ServerSteamId = match.ServerSteamId,
                GameTime = TimeSpan.FromSeconds(match.GameTime),
                Radiant = new TeamModel
                {
                    Id = match.TeamIdRadiant,
                    Name = match.TeamNameRadiant,
                    Lead = match.RadiantLead > 0 ? match.RadiantLead : 0,
                    Score = match.RadiantScore,
                    Logo = match.TeamLogoRadiant.HasValue
                        ? await _imageRepository.GetSteamImageUrlAsync(match.TeamLogoRadiant.Value)
                        : string.Empty
                },
                Dire = new TeamModel
                {
                    Id = match.TeamIdDire,
                    Name = match.TeamNameDire,
                    Lead = match.RadiantLead < 0 ? Math.Abs(match.RadiantLead) : 0,
                    Score = match.DireScore,
                    Logo = match.TeamLogoDire.HasValue
                        ? await _imageRepository.GetSteamImageUrlAsync(match.TeamLogoDire.Value)
                        : string.Empty
                }
            };
        }
    }
}