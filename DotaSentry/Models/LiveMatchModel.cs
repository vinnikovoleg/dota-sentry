using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaSentry.Models
{
    public class LiveMatchModel
    {
        public long MatchId { get; set; }
        public ulong ServerSteamId { get; set; }
        public TimeSpan GameTime { get; set; }
        public TeamModel Radiant { get; set; }
        public TeamModel Dire { get; set; }
    }

    public class TeamModel
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public long Lead { get; set; }
        public long Score { get; set; }
    }
}
