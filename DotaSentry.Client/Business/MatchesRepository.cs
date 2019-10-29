using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotaSentry.Client.Business.DataAccess.Interfaces;
using DotaSentry.Client.Models;

namespace DotaSentry.Client.Business
{
    public class MatchesRepository : IMatchesRepository
    {
        private readonly JsonClient _jsonClient;

        public MatchesRepository(JsonClient jsonClient)
        {
            _jsonClient = jsonClient;
        }

        public async Task<Match> GetMatchAsync(long matchId)
        {
            var url = $"https://api.opendota.com/api/matches/{matchId}";
            return await _jsonClient.Get<Match>(url);
        }
    }
}
