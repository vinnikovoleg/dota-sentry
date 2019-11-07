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
        private readonly MongoHeroesRepository _mongoHeroesRepository;
        private readonly MatchesRepository _matchesRepository;

        public LiveController(
            LiveMatchesService liveMatchesService,
            TeamRepository teamRepository,
            MongoHeroesRepository mongoHeroesRepository, 
            MatchesRepository matchesRepository)
        {
            _liveMatchesService = liveMatchesService;
            _teamRepository = teamRepository;
            _mongoHeroesRepository = mongoHeroesRepository;
            _matchesRepository = matchesRepository;
        }

        [HttpGet]
        public async Task<List<LiveMatchModel>> GetLiveAsync()
        {
            var liveMatches = await _liveMatchesService.GetLiveMatchesAsync();
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
        public async Task<GetRealtimeMatchStatsResponse> GetTestAsync(string serverSteamId)
        {
            //return await _teamRepository.GetTeamInfoAsync(7359917);
            //_mongoHeroesRepository.Create(new HeroData
            //{
            //    Id = 1,
            //    Name = "Test",
            //    LocalizedName = "test 111"
            //});

            //var hero = _mongoHeroesRepository.Get(1);     90130323322593281
            ulong id = Convert.ToUInt64(serverSteamId.Substring(1, serverSteamId.Length- 1));
            return await _matchesRepository.GetRealtimeMatchStatsAsync(id);
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