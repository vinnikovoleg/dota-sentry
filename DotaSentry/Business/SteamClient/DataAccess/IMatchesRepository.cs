using System.Threading.Tasks;
using DotaSentry.Models.SteamClient;

namespace DotaSentry.Business.SteamClient.DataAccess
{
    public interface IMatchesRepository
    {
        Task<GetTopLiveGamesResponse> GetTopLiveMatchesAsync(int partnerId = 0);
        Task<GetRealtimeMatchStatsResponse> GetRealtimeMatchStatsAsync(ulong serverSteamId);
    }
}