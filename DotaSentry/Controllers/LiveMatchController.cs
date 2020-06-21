using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business;
using DotaSentry.Business.DataAccess;
using DotaSentry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveMatchController : ControllerBase
    {
        // TODO: refactor this, some mess here
        private readonly LiveMatchRepository _liveMatchRepository;
        private readonly IMemoryCache _memoryCache;

        public LiveMatchController(
            LiveMatchRepository liveMatchRepository, IMemoryCache memoryCache)
        {
            _liveMatchRepository = liveMatchRepository;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<ActionResult<List<LiveMatch>>> GetLiveAsync()
        {
            return _memoryCache.Get<List<LiveMatch>>(LiveMatchCacheUpdateTask.MatchCacheKey);
        }
    }
}