using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess;
using DotaSentry.Business.DataAccess.Steam;
using DotaSentry.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveController : ControllerBase
    {
        private readonly IMatchRepository _steamMatchRepository;

        public LiveController(
            SteamMatchRepository steamMatchRepository)
        {
            _steamMatchRepository = steamMatchRepository;
        }

        [HttpGet]
        public async Task<List<LiveMatchModel>> GetLiveAsync()
        {
            return await _steamMatchRepository.GetLiveAsync();
        }

        [HttpGet]
        [Route("{serverSteamId}")]
        public async Task<LiveMatchStatsModel> GetTestAsync(ulong serverSteamId)
        {
            return await _steamMatchRepository.GetLiveStatsAsync(serverSteamId);
        }
    }
}