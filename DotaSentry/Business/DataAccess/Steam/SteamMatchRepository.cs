using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess.Steam.Client;
using DotaSentry.Models;
using DotaSentry.Models.SteamClient;

namespace DotaSentry.Business.DataAccess.Steam
{
    public class SteamMatchRepository : IMatchRepository
    {
        private readonly SteamDotaClient _steamDotaClient;
        private readonly SteamImageRepository _steamImageRepository;
        private readonly HeroesRepository _heroesRepository;
        private readonly InventoryItemService _inventoryItemService;

        public SteamMatchRepository(
            SteamDotaClient steamDotaClient,
            SteamImageRepository steamImageRepository,
            HeroesRepository heroesRepository,
            InventoryItemService inventoryItemService)
        {
            _steamDotaClient = steamDotaClient;
            _steamImageRepository = steamImageRepository;
            _heroesRepository = heroesRepository;
            _inventoryItemService = inventoryItemService;
        }

        public async Task<List<LiveMatchModel>> GetLiveAsync()
        {
            var liveMatches = await _steamDotaClient.GetTopLiveMatchesAsync();
            var matchModels = new List<LiveMatchModel>();
            foreach (var liveMatch in liveMatches.GameList)
            {
                var matchModel = await BuildLiveMatchModel(liveMatch);
                matchModels.Add(matchModel);
            }

            return matchModels;
        }

        public async Task<LiveMatchStatsModel> GetLiveStatsAsync(ulong serverSteamId)
        {
            var matchStats = await _steamDotaClient.GetRealtimeMatchStatsAsync(serverSteamId);
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
            var heroes = await _heroesRepository.GetHeroesAsync();
            var items = await _inventoryItemService.GetItemsAsync();

            HeroModel GetHero(long heroId)
            {
                return heroes.ContainsKey(heroId) ? heroes[heroId] : _heroesRepository.GetUnknownHero();
            }

            InventoryItemModel GetItem(long itemId)
            {
                return items.ContainsKey(itemId) ? items[itemId] : new InventoryItemModel {Name = "Unknown"};
            }

            return new LiveTeamStatsModel
            {
                Id = team.TeamId,
                Name = team.TeamName,
                Score = team.Score,
                NetWorth = team.NetWorth,
                Logo = await _steamImageRepository.GetSteamImageUrlAsync(team.TeamLogo),
                Bans = bans.Where(b => b.Team == team.TeamNumber).Select(b => GetHero(b.HeroId)).ToList(),
                Picks = picks.Where(b => b.Team == team.TeamNumber).Select(b => GetHero(b.HeroId)).ToList(),
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
                        Hero = GetHero(p.HeroId),
                        Items = p.Items.Select(GetItem).ToList()
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
                        ? await _steamImageRepository.GetSteamImageUrlAsync(match.TeamLogoRadiant.Value)
                        : string.Empty
                },
                Dire = new TeamModel
                {
                    Id = match.TeamIdDire,
                    Name = match.TeamNameDire,
                    Lead = match.RadiantLead < 0 ? Math.Abs(match.RadiantLead) : 0,
                    Score = match.DireScore,
                    Logo = match.TeamLogoDire.HasValue
                        ? await _steamImageRepository.GetSteamImageUrlAsync(match.TeamLogoDire.Value)
                        : string.Empty
                }
            };
        }
    }
}