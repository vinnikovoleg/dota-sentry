using System;

namespace DotaSentry.Models
{
    public class LiveMatch
    {
        public long MatchId { get; set; }
        public ulong ServerSteamId { get; set; }
        public TimeSpan GameTime { get; set; }
        public Team Radiant { get; set; }
        public Team Dire { get; set; }
        public League League { get; set; }
    }
}
