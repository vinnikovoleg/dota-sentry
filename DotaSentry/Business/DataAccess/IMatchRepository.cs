using System.Collections.Generic;
using System.Threading.Tasks;
using DotaSentry.Models;

namespace DotaSentry.Business.DataAccess
{
    public interface IMatchRepository
    {
        Task<List<LiveMatchModel>> GetLiveAsync();
        Task<LiveMatchStatsModel> GetLiveStatsAsync(ulong serverSteamId);
    }
}