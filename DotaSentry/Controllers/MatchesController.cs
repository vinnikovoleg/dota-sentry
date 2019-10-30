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
using Microsoft.Extensions.Caching.Memory;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchesRepository _matchesRepository;
        private readonly IHeroesRepository _heroesRepository;
        private readonly IMemoryCache _cache;
        private readonly MatchesBuilder _matchesBuilder;

        public MatchesController(
            IMatchesRepository matchesRepository,
            MatchesBuilder matchesBuilder,
            IHeroesRepository heroesRepository,
            IMemoryCache cache)
        {
            _matchesRepository = matchesRepository;
            _matchesBuilder = matchesBuilder;
            _heroesRepository = heroesRepository;
            _cache = cache;
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

            var heroes = GetHeroes();
            await Task.WhenAll(liveMatches, heroes);
            return _matchesBuilder.BuildLiveMatches(liveMatches.Result, heroes.Result);
        }

        public async Task<List<Hero>> GetHeroes()
        {
            var cacheKey = "heroes";
            var heroes = _cache.Get<List<Hero>>(cacheKey);
            if (heroes != null)
            {
                return heroes;
            }

            heroes = await _heroesRepository.GetHeroesAsync();
            _cache.Set(cacheKey, heroes, TimeSpan.FromHours(50));

            return heroes;
        }
    }
}