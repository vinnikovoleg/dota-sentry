﻿using System;
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
        private readonly HeroesService _heroesService;

        public LiveController(
            LiveMatchesService liveMatchesService,
            HeroesService heroesService)
        {
            _liveMatchesService = liveMatchesService;
            _heroesService = heroesService;
        }

        [HttpGet]
        public async Task<List<LiveMatchModel>> GetLiveAsync()
        {
            return await _liveMatchesService.GetLiveMatchesAsync();
        }

        [HttpGet]
        [Route("{serverSteamId}")]
        public async Task<GetRealtimeMatchStatsResponse> GetTestAsync(ulong serverSteamId)
        {
            return await _liveMatchesService.GetRealtimeMatchStatsAsync(serverSteamId);
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
            //var heroes = await _heroesService.GetHeroesAsync(1, 2, 15, 16);
            return await _liveMatchesService.GetRealtimeMatchStatsAsync(90130323322593281);
        }
    }
}