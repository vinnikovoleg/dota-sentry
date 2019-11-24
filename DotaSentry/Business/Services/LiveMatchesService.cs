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

        public async Task<LiveMatchStatsModel> GetRealtimeMatchStatsAsync(ulong serverSteamId)
        {
            var matchStats = await _matchesRepository.GetRealtimeMatchStatsAsync(serverSteamId);
            var radiantTeam =
                await BuildLiveTeamStats(matchStats.Teams[0], matchStats.Match.Picks, matchStats.Match.Bans);
            var direTeam = await BuildLiveTeamStats(matchStats.Teams[1], matchStats.Match.Picks, matchStats.Match.Bans);

            return new LiveMatchStatsModel
            {
                ServerSteamId = matchStats.Match.ServerSteamId,
                GameTime = TimeSpan.FromSeconds(matchStats.Match.GameTime),
                GoldGraph = matchStats.GraphData.GraphGold,
                Radiant = radiantTeam,
                Dire = direTeam
            };
        }

        private async Task<LiveTeamStatsModel> BuildLiveTeamStats(RealtimeTeam team, List<HeroPick> picks,
            List<HeroPick> bans)
        {
            var heroes = await _heroesService.GetHeroesAsync();
            var items = await _itemsService.GetItemsAsync();
            return new LiveTeamStatsModel
            {
                Id = team.TeamId,
                Name = team.TeamName,
                Score = team.Score,
                NetWorth = team.NetWorth,
                Logo = await _imageService.GetSteamImageUrlAsync(team.TeamLogo),
                Bans = bans.Where(b => b.Team == team.TeamNumber).Select(b => heroes[b.Hero]).ToList(),
                Picks = picks.Where(b => b.Team == team.TeamNumber).Select(b => heroes[b.Hero]).ToList(),
                Players = team.Players.Where(p => p.Team == team.TeamNumber)
                    .Select(p => new PlayerModel
                    {
                        Id = p.PlayerId,
                        AccountId = p.AccountId,
                        Name = p.Name,
                        Assists = p.AssistsCount,
                        Deaths = p.DeathCount,
                        Kills = p.KillCount,
                        Denies = p.DeniesCount,
                        LastHits = p.LastHitsCount,
                        Gold = p.Gold,
                        NetWorth = p.NetWorth,
                        Level = p.Level,
                        Hero = heroes[p.HeroId],
                        Items = p.Items.Select(itemId => items[itemId]).ToList()
                    })
                    .ToList()
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
                    Id = match.TeamIdRadiant,
                    Name = match.TeamNameRadiant,
                    Lead = match.RadiantLead > 0 ? match.RadiantLead : 0,
                    Score = match.RadiantScore,
                    Logo = match.TeamLogoRadiant.HasValue
                        ? await _imageService.GetSteamImageUrlAsync(match.TeamLogoRadiant.Value)
                        : string.Empty
                },
                Dire = new TeamModel
                {
                    Id = match.TeamIdDire,
                    Name = match.TeamNameDire,
                    Lead = match.RadiantLead < 0 ? Math.Abs(match.RadiantLead) : 0,
                    Score = match.DireScore,
                    Logo = match.TeamLogoDire.HasValue
                        ? await _imageService.GetSteamImageUrlAsync(match.TeamLogoDire.Value)
                        : string.Empty
                }
            };
        }
    }
}