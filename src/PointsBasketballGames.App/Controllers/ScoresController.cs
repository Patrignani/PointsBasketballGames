using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointsBasketballGames.Domain.Core.DTOs;
using PointsBasketballGames.Domain.Core.Interfaces.Services;

namespace PointsBasketballGames.App.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreServices _score;
        public ScoresController(IScoreServices score)
        {
            _score = score;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _score.GetResult());
        }

        [HttpPost]
        public async Task<ActionResult> Post(ScoreBasic score)
        {
            return Ok(await _score.AddAsync(score));
        }
    }
}