﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace DotaSentry.Business.Services
{
    public class ItemsService
    {
        private readonly string _itemsDataPath = "StaticFiles/Data/items.json";
        private readonly IWebHostEnvironment _environment;
        private readonly IMemoryCache _memoryCache;

        public ItemsService(
            IMemoryCache memoryCache,
            IWebHostEnvironment environment)
        {
            _memoryCache = memoryCache;
            _environment = environment;
        }

        public async Task<Dictionary<long, ItemModel>> GetItemsAsync()
        {
            async Task<Dictionary<long, ItemModel>> ReadHeroesAsync()
            {
                var dataPath = Path.Combine(_environment.WebRootPath, _itemsDataPath);

                if (!File.Exists(dataPath))
                {
                    return new Dictionary<long, ItemModel>();
                }

                var json = await File.ReadAllTextAsync(dataPath);
                var gameItems = JsonConvert.DeserializeObject<ItemsData>(json);
                return gameItems.Items.ToDictionary(it => it.Id, it => it);
            }

            const string cacheKey = "items_cache";
            return await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
                return await ReadHeroesAsync();
            });
        }

        private class ItemsData
        {
            public List<ItemModel> Items { get; set; }
        }
    }
}