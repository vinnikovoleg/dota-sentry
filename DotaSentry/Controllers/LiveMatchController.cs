using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.DataAccess;
using DotaSentry.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaSentry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveMatchController : ControllerBase
    {
        private readonly LiveMatchRepository _liveMatchRepository;

        public LiveMatchController(
            LiveMatchRepository liveMatchRepository)
        {
            _liveMatchRepository = liveMatchRepository;
        }

        [HttpGet]
        [Route("{partnerId}")]
        public async Task<ActionResult<List<LiveMatch>>> GetLiveAsync(int partnerId = 0)
        {
            if (0 > partnerId || partnerId > 3)
            {
                return BadRequest();
            }

            return await _liveMatchRepository.GetAsync(partnerId);
        }
    }
}