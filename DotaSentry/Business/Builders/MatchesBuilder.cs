using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Client.Models;
using DotaSentry.Models;

namespace DotaSentry.Business.Builders
{
    public class MatchesBuilder
    {
        public List<LiveMatchModel> BuildLiveMatches(List<LiveMatch> liveMatches, List<Hero> heroes)
        {
            return liveMatches.Select(m => BuildLiveMatch(m, heroes)).ToList();
        }

        private LiveMatchModel BuildLiveMatch(LiveMatch liveMatch, List<Hero> heroes)
        {
            var isRadiantLeads = liveMatch.RadiantLead > 0;
            var radiantPlayers = liveMatch.Players.Take(5).ToList();
            var radianTeamName = radiantPlayers.Select(p => p.TeamName).Distinct().Count() == 1
                ? radiantPlayers[0].TeamName : LocalizableStrings.Radiant;


            var direPlayers = liveMatch.Players.Skip(5).Take(5).ToList();
            var direTeamName = direPlayers.Select(p => p.TeamName).Distinct().Count() == 1
                ? radiantPlayers[0].TeamName : LocalizableStrings.Dire;
            return new LiveMatchModel
            {
                Radiant = new LiveTeamModel
                {
                    Name = radianTeamName,
                    Score = liveMatch.RadiantScore,
                    Lead = isRadiantLeads ? liveMatch.RadiantLead : 0
                },
                Dire = new LiveTeamModel
                {
                    Name = direTeamName,
                    Lead = isRadiantLeads ? 0 : Math.Abs(liveMatch.RadiantLead),
                    Score = liveMatch.DireScore
                }
            };
        }
    }
}
