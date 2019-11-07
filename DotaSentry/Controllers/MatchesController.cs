using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DotaSentry.Business.Services;
using DotaSentry.Models;
using DotaSentry.SteamClient.Business.DataAccess;
using DotaSentry.SteamClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly LiveMatchesService _liveMatchesService;
        private readonly TeamRepository _teamRepository;

        public MatchesController(
            LiveMatchesService liveMatchesService,
            TeamRepository teamRepository)
        {
            _liveMatchesService = liveMatchesService;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        [Route("live")]
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
            //        Dire = new TeamModel
            //        {
            //            Name = "Virtus Pro Virtus Pro",
            //            Lead = 34102,
            //            Score = 12,
            //            Logo = "/StaticFiles/images/101724518978773491.png"
            //        },
            //        Radiant = new TeamModel
            //        {
            //            Name = "NaVi",
            //            Lead = 0,
            //            Score = 5,
            //            Logo = "/StaticFiles/images/777357465302429517.png"
            //        }

            //    }
            //};
        }

        [HttpGet]
        [Route("test")]
        public async Task<GetTeamInfoResponse> GetTestAsync()
        {
            //return await _teamRepository.GetTeamInfoAsync(7359917);
            return null;
        }
    }
}