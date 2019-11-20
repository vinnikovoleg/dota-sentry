using System;
using System.Collections.Generic;

namespace DotaSentry.Models
{
    public class LiveMatchStats
    {
        public long ServerSteamId { get; set; }
        public TimeSpan GameTime { get; set; }
        public LiveTeamStats Radiant { get; set; }
        public LiveTeamStats Dire { get; set; }
        public List<long> GoldGraph { get; set; }
    }

    public class LiveTeamStats
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public long Score { get; set; }
        public List<HeroModel> Picks { get; set; }
        public List<HeroModel> Bans { get; set; }
        public List<PlayerModel> Players { get; set; }
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