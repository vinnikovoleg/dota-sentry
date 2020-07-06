using System.Threading.Tasks;
using DotaSentry.Business.DataAccess;
using DotaSentry.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatsController: ControllerBase
    {
        private readonly MatchStatsSteamRepository _matchStatsSteamRepository;

        public MatchStatsController(MatchStatsSteamRepository matchStatsSteamRepository)
        {
            _matchStatsSteamRepository = matchStatsSteamRepository;
        }

        [HttpGet]
        [Route("{serverSteamId}")]
        public async Task<ActionResult<MatchStats>> GetStatsAsync(ulong serverSteamId)
        {
            return await _matchStatsSteamRepository.GetAsync(serverSteamId);
        }
    }
}