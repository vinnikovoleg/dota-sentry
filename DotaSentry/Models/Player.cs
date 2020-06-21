using System.Collections.Generic;

namespace DotaSentry.Models
{
    public class Player
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string Name { get; set; }
        public Hero Hero { get; set; }
        public long Kills { get; set; }
        public long Deaths { get; set; }
        public long Assists { get; set; }
        public long LastHits { get; set; }
        public long Denies { get; set; }
        public long Gold { get; set; }
        public long NetWorth { get; set; }
        public long Level { get; set; }
        public List<InventoryItem> Items { get; set; }
    }
}