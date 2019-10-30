using System.Collections.Generic;
using System.Threading.Tasks;
using DotaSentry.Client.Business.DataAccess.Interfaces;
using DotaSentry.Client.Models;

namespace DotaSentry.Client.Business.DataAccess
{
    public class MatchesRepository : IMatchesRepository
    {
        private readonly JsonClient _jsonClient;
        private readonly string _host = "https://api.opendota.com";

        public MatchesRepository(JsonClient jsonClient)
        {
            _jsonClient = jsonClient;
        }

        public async Task<Match> GetMatchAsync(long matchId)
        {
            var url = $"{_host}/api/matches/{matchId}";
            return await _jsonClient.GetAsync<Match>(url);
        }

        public async Task<List<LiveMatch>> GetLiveMatchAsync()
        {
            var url = $"{_host}/api/live/";
            return await _jsonClient.GetAsync<List<LiveMatch>>(url);
        }
    }
}
