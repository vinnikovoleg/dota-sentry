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
        private readonly MatchStatsRepository _matchStatsRepository;

        public MatchStatsController(MatchStatsRepository matchStatsRepository)
        {
            _matchStatsRepository = matchStatsRepository;
        }

        [HttpGet]
        [Route("/stats/{serverSteamId}")]
        public async Task<ActionResult<MatchStats>> GetStatsAsync(ulong serverSteamId)
        {
            return await _matchStatsRepository.GetAsync(serverSteamId);
        }
    }
}