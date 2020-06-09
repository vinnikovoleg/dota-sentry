using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess;
using DotaSentry.Models;
using DotaSentry.Models.SteamClient;

namespace DotaSentry.Business.Builders
{
    public class MatchStatsBuilder
    {
        private readonly ImageRepository _imageRepository;
        private readonly HeroesRepository _heroesRepository;
        private readonly InventoryItemRepository _inventoryItemRepository;

        public MatchStatsBuilder(
            ImageRepository imageRepository,
            HeroesRepository heroesRepository,
            InventoryItemRepository inventoryItemRepository)
        {
            _imageRepository = imageRepository;
            _heroesRepository = heroesRepository;
            _inventoryItemRepository = inventoryItemRepository;
        }

        public async Task<LiveMatchStatsModel> Build(GetMatchStatsResponse matchStats)
        {
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
        
        private async Task<LiveTeamStatsModel> BuildLiveTeamStats(Team team, List<HeroPick> picks,
            List<HeroPick> bans)
        {
            var heroes = await _heroesRepository.GetHeroesAsync();
            var items = await _inventoryItemRepository.GetItemsAsync();

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
                Logo = await _imageRepository.GetSteamImageUrlAsync(team.TeamLogo),
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
    }
}