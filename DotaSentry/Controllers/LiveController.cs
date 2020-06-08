using System;
using System.Collections.Generic;
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
        public async Task<List<LiveMatchModel>> GetLiveAsync()
        {
            return await _matchRepository.GetLiveAsync();
        }

        [HttpGet]
        [Route("{serverSteamId}")]
        public async Task<LiveMatchStatsModel> GetTestAsync(ulong serverSteamId)
        {
            return await _matchRepository.GetLiveStatsAsync(serverSteamId);
        }
    }
}