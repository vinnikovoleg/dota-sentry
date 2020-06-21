using System;
using System.Collections.Generic;

namespace DotaSentry.Models
{
    public class MatchStats
    {
        public long ServerSteamId { get; set; }
        public TimeSpan GameTime { get; set; }
        public LiveTeamStats Radiant { get; set; }
        public LiveTeamStats Dire { get; set; }
        public List<long> GoldGraph { get; set; }
    }
}