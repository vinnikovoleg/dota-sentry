using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DotaSentry.Business.Models;
using DotaSentry.Business.MongoClient;
using DotaSentry.Business.Services;
using DotaSentry.Models;
using DotaSentry.SteamClient.Business.DataAccess;
using DotaSentry.SteamClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveController : ControllerBase
    {
        private readonly LiveMatchesService _liveMatchesService;
        private readonly TeamRepository _teamRepository;
        private readonly HeroesService _heroesService;
        private readonly MatchesRepository _matchesRepository;

        public LiveController(
            LiveMatchesService liveMatchesService,
            TeamRepository teamRepository,
            MatchesRepository matchesRepository,
            HeroesService heroesService)
        {
            _liveMatchesService = liveMatchesService;
            _teamRepository = teamRepository;
            _matchesRepository = matchesRepository;
            _heroesService = heroesService;
        }

        [HttpGet]
        public async Task<List<LiveMatchModel>> GetLiveAsync()
        {
            var liveMatches = await _liveMatchesService.GetLiveMatchesAsync();
            var heroes = await _heroesService.GetHeroesAsync(1, 2, 15, 16);
            return liveMatches
                .Where(m => !string.IsNullOrEmpty(m.Radiant.Name) && !string.IsNullOrEmpty(m.Dire.Name))
                .ToList();

            //return new List<LiveMatchModel>
            //{
            //    new LiveMatchModel
            //    {
            //        MatchId = 1,
            //        GameTime = TimeSpan.FromSeconds(123),
            //        Dire = new TeamModel
            //        {
            //            Name = "Virtus Pro Virtus Pro",
            //            Lead = 0,
            //            Score = 12,
            //            Logo = "/StaticFiles/images/101724518978773491.png"
            //        },
            //        Radiant = new TeamModel
            //        {
            //            Name = "NaVi",
            //            Lead = 35493,
            //            Score = 5,
            //            Logo = "/StaticFiles/images/777357465302429517.png"
            //        }

            //    }
            //};
        }

        [HttpGet]
        [Route("{serverSteamId}")]
        public async Task<GetRealtimeMatchStatsResponse> GetTestAsync(ulong serverSteamId)
        {
            //return await _teamRepository.GetTeamInfoAsync(7359917);
            //_mongoHeroesRepository.Create(new HeroData
            //{
            //    Id = 1,
            //    Name = "Test",
            //    LocalizedName = "test 111"
            //});

            //var hero = _mongoHeroesRepository.Get(1);     90130323322593281
            return await _matchesRepository.GetRealtimeMatchStatsAsync(serverSteamId);
        }

        [HttpGet]
        [Route("test")]
        public async Task<GetRealtimeMatchStatsResponse> GetTestAsync()
        {
            //return await _teamRepository.GetTeamInfoAsync(7359917);
            //_mongoHeroesRepository.Create(new HeroData
            //{
            //    Id = 1,
            //    Name = "Test",
            //    LocalizedName = "test 111"
            //});

            //var hero = _mongoHeroesRepository.Get(1);

            return await _matchesRepository.GetRealtimeMatchStatsAsync(90130323322593281);
        }
    }
}