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
        private readonly HeroesService _heroesService;
        private readonly ItemsService _itemsService;

        public LiveMatchesService(
            IMatchesRepository matchesRepository,
            ImageService imageService,
            HeroesService heroesService, 
            ItemsService itemsService)
        {
            _matchesRepository = matchesRepository;
            _imageService = imageService;
            _heroesService = heroesService;
            _itemsService = itemsService;
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

        public async Task<LiveMatchStats> GetRealtimeMatchStatsAsync(ulong serverSteamId)
        {
            var matchStats = await _matchesRepository.GetRealtimeMatchStatsAsync(serverSteamId);
            var radiantTeam = await BuildLiveTeamStats(matchStats.Teams[0], matchStats.Match.Picks, matchStats.Match.Bans);
            var direTeam = await BuildLiveTeamStats(matchStats.Teams[1], matchStats.Match.Picks, matchStats.Match.Bans);
            
            return new LiveMatchStats
            {
                ServerSteamId = matchStats.Match.ServerSteamId,
                Radiant = radiantTeam,
                Dire = direTeam
            };
        }

        private async Task<LiveTeamStats> BuildLiveTeamStats(RealtimeTeam team, List<HeroPick> picks, List<HeroPick> bans)
        {
            var heroes = await _heroesService.GetHeroesAsync();
            return new LiveTeamStats
            {
                Id = team.TeamId,
                Name = team.TeamName,
                Logo = await _imageService.GetSteamImageUrlAsync(team.TeamLogo),
                Bans = bans.Where(b => b.Team == team.TeamNumber).Select(b => heroes[b.Hero]).ToList(),
                Picks = picks.Where(b => b.Team == team.TeamNumber).Select(b => heroes[b.Hero]).ToList()
            };
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
