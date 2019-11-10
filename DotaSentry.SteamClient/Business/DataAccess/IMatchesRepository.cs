using System.Threading.Tasks;
using DotaSentry.SteamClient.Models;

namespace DotaSentry.SteamClient.Business.DataAccess
{
    public interface IMatchesRepository
    {
        Task<GetTopLiveGamesResponse> GetTopLiveMatchesAsync(int partnerId = 0);
        Task<GetRealtimeMatchStatsResponse> GetRealtimeMatchStatsAsync(ulong serverSteamId);
    }
}