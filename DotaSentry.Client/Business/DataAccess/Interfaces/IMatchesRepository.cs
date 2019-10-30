using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotaSentry.Client.Models;

namespace DotaSentry.Client.Business.DataAccess.Interfaces
{
    public interface IMatchesRepository
    {
        Task<Match> GetMatchAsync(long matchId);
        Task<List<LiveMatch>> GetLiveMatchAsync();
    }
}
