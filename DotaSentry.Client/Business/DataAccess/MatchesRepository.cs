using System.Collections.Generic;
using System.Threading.Tasks;
using DotaSentry.Client.Business.DataAccess.Interfaces;
using DotaSentry.Client.Models;

namespace DotaSentry.Client.Business.DataAccess
{
    public class MatchesRepository : BaseRepository, IMatchesRepository
    {
        public MatchesRepository(JsonClient jsonClient)
            : base(jsonClient)
        {
        }

        public async Task<Match> GetMatchAsync(long matchId)
        {
            var url = $"{Host}/api/matches/{matchId}";
            return await JsonClient.GetAsync<Match>(url);
        }

        public async Task<List<LiveMatch>> GetLiveMatchAsync()
        {
            var url = $"{Host}/api/live/";
            return await JsonClient.GetAsync<List<LiveMatch>>(url);
        }
    }
}
