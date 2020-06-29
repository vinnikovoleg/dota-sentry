using System;
using System.Collections.Generic;
using DotaSentry.Business.DataAccess;
using DotaSentry.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveMatchController : ControllerBase
    {
        private readonly LiveMatchStoreRepository _liveMatchStoreRepository;

        public LiveMatchController(LiveMatchStoreRepository liveMatchStoreRepository)
        {
            _liveMatchStoreRepository = liveMatchStoreRepository;
        }

        [HttpGet]
        public ActionResult<List<LiveMatch>> Get()
        {
            return _liveMatchStoreRepository.Get();
        }
    }
}