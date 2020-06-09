using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess;
using DotaSentry.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveController : ControllerBase
    {
        private readonly MatchRepository _matchRepository;

        public LiveController(
            MatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        [HttpGet]
        [Route("{partnerId}")]
        public async Task<ActionResult<List<LiveMatchModel>>> GetLiveAsync(int partnerId = 0)
        {
            if (0 > partnerId || partnerId > 3)
            {
                return BadRequest();
            }

            return await _matchRepository.GetLiveAsync(partnerId);
        }

        [HttpGet]
        [Route("/stats/{serverSteamId}")]
        public async Task<ActionResult<LiveMatchStatsModel>> GetStatsAsync(ulong serverSteamId)
        {
            return await _matchRepository.GetLiveStatsAsync(serverSteamId);
        }
    }
}