using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DotaSentry.Business.Services;
using DotaSentry.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveController : ControllerBase
    {
        private readonly LiveMatchesService _liveMatchesService;
        private readonly HeroesService _heroesService;
        private readonly ItemsService _itemsService;

        public LiveController(
            LiveMatchesService liveMatchesService,
            HeroesService heroesService,
            ItemsService itemsService)
        {
            _liveMatchesService = liveMatchesService;
            _heroesService = heroesService;
            _itemsService = itemsService;
        }

        [HttpGet]
        public async Task<List<LiveMatchModel>> GetLiveAsync()
        {
            return await _liveMatchesService.GetLiveMatchesAsync();
        }

        [HttpGet]
        [Route("{serverSteamId}")]
        public async Task<LiveMatchStatsModel> GetTestAsync(ulong serverSteamId)
        {
            return await _liveMatchesService.GetRealtimeMatchStatsAsync(serverSteamId);
        }

        [HttpGet]
        [Route("test")]
        public async Task<Dictionary<long, ItemModel>> GetTestAsync()
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
            //return await _liveMatchesService.GetRealtimeMatchStatsAsync(90130323322593281);
            return await _itemsService.GetItemsAsync();
        }
    }
}