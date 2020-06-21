using System.Collections.Generic;

namespace DotaSentry.Models
{
    public class LiveTeamStats : Team
    {
        public List<Hero> Picks { get; set; }
        public List<Hero> Bans { get; set; }
        public List<Player> Players { get; set; }
        public long NetWorth { get; set; }
    }
}