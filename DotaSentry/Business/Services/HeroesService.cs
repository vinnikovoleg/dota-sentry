﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using DotaSentry.Business.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotaSentry.Business.Services
{
    public class HeroesService
    {
        private readonly string _heroesDataPath = "StaticFiles/Data/heroes.json";
        private readonly IWebHostEnvironment _environment;
        private readonly IMemoryCache _memoryCache;

        public HeroesService(
            IWebHostEnvironment environment,
            IMemoryCache memoryCache)
        {
            _environment = environment;
            _memoryCache = memoryCache;
        }

        public async Task<List<Hero>> GetHeroesAsync(params long[] ids)
        {
            var heroes = await GetHeroesAsync();
            return heroes.FindAll(m => ids.Contains(m.Id));
        }

        private async Task<List<Hero>> GetHeroesAsync()
        {
            async Task<List<Hero>> ReadHeroesAsync()
            {
                var dataPath = Path.Combine(_environment.WebRootPath, _heroesDataPath);

                if (!File.Exists(dataPath))
                {
                    return new List<Hero>();
                }

                var json = await File.ReadAllTextAsync(dataPath);
                var heroes = JsonConvert.DeserializeObject<HeroesData>(json);

                return heroes.Heroes;
            }

            const string cacheKey = "heroes_cache";
            return await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
                return await ReadHeroesAsync();
            });

        }

        private class HeroesData
        {
            public List<Hero> Heroes { get; set; }
        }
    }
}