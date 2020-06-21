using System;

namespace DotaSentry.Models
{
    public class League
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Tier { get; set; }
        public long Region { get; set; }
        public DateTime MostRecentActivity { get; set; }
        public long TotalPrizePool { get; set; }
        public DateTime StartTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
        public long Status { get; set; }
    }

    public enum LeagueStatus
    {
        InProgress = 3,
        Completed = 5
    }
}