using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaSentry.Models
{
    public class LiveMatchModel
    {
        public LiveTeamModel Radiant { get; set; }
        public LiveTeamModel Dire { get; set; }
    }

    public class LiveTeamModel
    {
        public string Name { get; set; }
        public long Lead { get; set; }
        public long Score { get; set; }
        public List<LivePlayerModel> Players { get; set; } = new List<LivePlayerModel>();
    }

    public class LivePlayerModel
    {
        public string Name { get; set; }
        public HeroModel Hero { get; set; }
        public string TeamName { get; set; }
        public string TeamId { get; set; }
        public string TeamTag { get; set; }
    }
}
