using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess;
using DotaSentry.Business.DataAccess.Steam.Models;
using DotaSentry.Models;

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

        public async Task<MatchStats> Build(GetMatchStatsSteamResponse matchStatsSteam)
        {
            var radiantTeam =
                await BuildLiveTeamStats(matchStatsSteam.Teams[0], matchStatsSteam.SteamMatch.Picks, matchStatsSteam.SteamMatch.Bans);
            var direTeam = await BuildLiveTeamStats(matchStatsSteam.Teams[1], matchStatsSteam.SteamMatch.Picks, matchStatsSteam.SteamMatch.Bans);

            return new MatchStats
            {
                ServerSteamId = matchStatsSteam.SteamMatch.ServerSteamId,
                GameTime = TimeSpan.FromSeconds(matchStatsSteam.SteamMatch.GameTime),
                GoldGraph = matchStatsSteam.SteamGraphData.GraphGold,
                Radiant = radiantTeam,
                Dire = direTeam
            };
        }
        
        private async Task<LiveTeamStats> BuildLiveTeamStats(SteamTeam steamTeam, List<SteamHeroPick> picks,
            List<SteamHeroPick> bans)
        {
            var heroes = await _heroesRepository.GetHeroesAsync();
            var items = await _inventoryItemRepository.GetItemsAsync();

            Hero GetHero(long heroId)
            {
                return heroes.ContainsKey(heroId) ? heroes[heroId] : _heroesRepository.GetUnknownHero();
            }

            InventoryItem GetItem(long itemId)
            {
                return items.ContainsKey(itemId) ? items[itemId] : new InventoryItem {Name = "Unknown"};
            }

            return new LiveTeamStats
            {
                Id = steamTeam.TeamId,
                Name = steamTeam.TeamName,
                Score = steamTeam.Score,
                NetWorth = steamTeam.NetWorth,
                Logo = await _imageRepository.GetSteamImageUrlAsync(steamTeam.TeamLogo),
                Bans = bans.Where(b => b.Team == steamTeam.TeamNumber).Select(b => GetHero(b.HeroId)).ToList(),
                Picks = picks.Where(b => b.Team == steamTeam.TeamNumber).Select(b => GetHero(b.HeroId)).ToList(),
                Players = steamTeam.Players.Where(p => p.Team == steamTeam.TeamNumber)
                    .Select(p => new Player
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