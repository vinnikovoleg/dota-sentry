using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Client.Business;
using DotaSentry.Client.Business.DataAccess.Interfaces;
using DotaSentry.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchesRepository _matchesRepository;

        public MatchesController(IMatchesRepository matchesRepository)
        {
            _matchesRepository = matchesRepository;
        }

        [HttpGet]
        [Route("{matchId}")]
        public async Task<Match> GetAsync(long matchId)
        {
            return await _matchesRepository.GetMatchAsync(matchId);
        }

        [HttpGet]
        [Route("live")]
        public async Task<List<LiveMatch>> GetLiveAsync()
        {
            return await _matchesRepository.GetLiveMatchAsync();
        }
    }
}