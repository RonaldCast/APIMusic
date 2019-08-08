using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.PlayListService;

namespace ApiMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListMusicController : ControllerBase
    {
        private readonly IPlayListService _playListService;

        public PlayListMusicController(IPlayListService playListService)
        {
            _playListService = playListService;

        }

        [HttpPost]
        public async Task<ActionResult> AddMusic([FromBody] PlayListMusicDTO model)
        {
            PlayList response = await _playListService.AddMusicAsync(model);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(new { message = " The music be added correctly" } );
        }
    }
}