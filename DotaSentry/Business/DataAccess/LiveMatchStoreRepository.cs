using System.Collections.Generic;
using DotaSentry.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DotaSentry.Business.DataAccess
{
    public class LiveMatchStoreRepository
    {
        private readonly IMemoryCache _memoryCache;

        public LiveMatchStoreRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<LiveMatch> Get()
        {
            return _memoryCache.Get<List<LiveMatch>>(LiveMatchStoreUpdateJob.MatchCacheKey);
        }
    }
}