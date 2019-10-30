using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.Builders;
using DotaSentry.Client.Business;
using DotaSentry.Client.Business.DataAccess.Interfaces;
using DotaSentry.Client.Models;
using DotaSentry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchesRepository _matchesRepository;
        private readonly IHeroesRepository _heroesRepository;
        private readonly MatchesBuilder _matchesBuilder;

        public MatchesController(
            IMatchesRepository matchesRepository,
            MatchesBuilder matchesBuilder,
            IHeroesRepository heroesRepository)
        {
            _matchesRepository = matchesRepository;
            _matchesBuilder = matchesBuilder;
            _heroesRepository = heroesRepository;
        }

        [HttpGet]
        [Route("{matchId}")]
        public async Task<Match> GetAsync(long matchId)
        {
            return await _matchesRepository.GetMatchAsync(matchId);
        }

        [HttpGet]
        [Route("live")]
        public async Task<List<LiveMatchModel>> GetLiveAsync()
        {
            var liveMatches = _matchesRepository.GetLiveMatchAsync();
            var heroes = _heroesRepository.GetHeroesAsync();
            await Task.WhenAll(liveMatches, heroes);
            return _matchesBuilder.BuildLiveMatches(liveMatches.Result, heroes.Result);
        }
    }
}