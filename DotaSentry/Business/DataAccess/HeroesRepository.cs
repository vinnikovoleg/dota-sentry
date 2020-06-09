using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace DotaSentry.Business.DataAccess
{
    public class HeroesRepository
    {
        private readonly string _heroesDataPath = "StaticFiles/Data/heroes.json";
        private readonly IWebHostEnvironment _environment;
        private readonly IMemoryCache _memoryCache;

        public HeroesRepository(
            IWebHostEnvironment environment,
            IMemoryCache memoryCache)
        {
            _environment = environment;
            _memoryCache = memoryCache;
        }

        public async Task<Dictionary<long, HeroModel>> GetHeroesAsync()
        {
            async Task<Dictionary<long, HeroModel>> ReadHeroesAsync()
            {
                var dataPath = Path.Combine(_environment.WebRootPath, _heroesDataPath);

                if (!File.Exists(dataPath))
                {
                    return new Dictionary<long, HeroModel>();
                }

                var json = await File.ReadAllTextAsync(dataPath);
                var heroes = JsonConvert.DeserializeObject<HeroesData>(json);

                return heroes.Heroes.ToDictionary(h => h.Id, h => h);
            }

            const string cacheKey = "heroes_cache";
            return await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
                return await ReadHeroesAsync();
            });

        }

        public HeroModel GetUnknownHero()
        {
            return new HeroModel
            {
                Name = "Unknown",
                LocalizedName = "Unknown"
            };
        }

        private class HeroesData
        {
            public List<HeroModel> Heroes { get; set; }
        }
    }
}
