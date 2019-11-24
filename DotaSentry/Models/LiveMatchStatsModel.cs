using System;
using System.Collections.Generic;

namespace DotaSentry.Models
{
    public class LiveMatchStatsModel
    {
        public long ServerSteamId { get; set; }
        public TimeSpan GameTime { get; set; }
        public LiveTeamStatsModel Radiant { get; set; }
        public LiveTeamStatsModel Dire { get; set; }
        public List<long> GoldGraph { get; set; }
    }

    public class LiveTeamStatsModel : TeamModel
    {
        public List<HeroModel> Picks { get; set; }
        public List<HeroModel> Bans { get; set; }
        public List<PlayerModel> Players { get; set; }
        public long NetWorth { get; set; }
    }
    
    public class PlayerModel
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string Name { get; set; }
        public HeroModel Hero { get; set; }
        public long Kills { get; set; }
        public long Deaths { get; set; }
        public long Assists { get; set; }
        public long LastHits { get; set; }
        public long Denies { get; set; }
        public long Gold { get; set; }
        public long NetWorth { get; set; }
        public long Level { get; set; }
        public List<ItemModel> Items { get; set; }
    }
}