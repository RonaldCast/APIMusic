using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.PlayListService;

namespace ApiMusic.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListController : ControllerBase
    {
        private readonly IPlayListService _playListService;
        private readonly IMapper _mapper;
     

        public PlayListController(IPlayListService playListService, IMapper mapper)
        {
            
            _playListService = playListService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all playlist
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PlayList>> Get()
        {
            var user = User.Claims.ToList();
            Guid UserId = Guid.Parse(user.FirstOrDefault(x => x.Type == "id").Value);
            IEnumerable<PlayList> response = await _playListService.GetAllPlayListAsync(UserId);
            return response;
        }

        /// <summary>
        /// Get Playlist for  id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayListInfoDTO>> Get([FromRoute]  Guid id)
        {
            PlayListInfoDTO response = await _playListService.GetPlayList(id);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        /// <summary>
        /// Create Play list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<PlayList>> Post([FromBody] PlayListDTO model)
        {
            PlayList playList = _mapper.Map<PlayList>(model);
            var user = User.Claims.ToList();
            playList.UserId = Guid.Parse(user.FirstOrDefault(x => x.Type == "id").Value);
            var response = await _playListService.InsertPlayListAsync(playList);

            if (response == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

     
        /// <summary>
        /// Delete playlist
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayList>> Delete([FromRoute] Guid id)
        {
            var response = await _playListService.DeletePlayListAsync(id);

            if (response)
            {
                return NotFound();
            }


            return Ok(response);
        }

        /// <summary>
        /// Update Playlist 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        //Put
        [HttpPut("{id}")]
        public async Task<ActionResult<PlayList>> Put([FromRoute] Guid id, [FromBody] PlayListDTO model)
        {
            PlayList playList = _mapper.Map<PlayList>(model);
            PlayList response = await _playListService.UpdatePlayListAsync(id, playList);

            if (response == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }
    }
}