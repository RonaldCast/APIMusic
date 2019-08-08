using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.MusicService;

namespace ApiMusic.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;
        public MusicController(IMusicService musicService,  IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all music
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Music>> Get()
        {
            IEnumerable<Music> musics = await _musicService.GetMusicsAsync();
            return musics;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> Get([FromRoute] Guid id)
        {
            Music response = await _musicService.GetMusicAsync(id);
             if (response == null)
            {
                return NotFound();
            }
            return  response;
        }


        /// <summary>
        /// Create Music
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<Music>> Post( [FromBody] MusicDTO model)
        {
            Music music = _mapper.Map<Music>(model);

            Music response = await _musicService.InsertMusicAsync(music);

            if (response == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(Get), response.Id, response);
        }


       /// <summary>
       /// Update music 
       /// </summary>
       /// <param name="id"></param>
       /// <param name="model"></param>
       /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Music>> Put([FromRoute] Guid id,[FromBody] MusicBasicInfoDTO model)
        {
            Music music = _mapper.Map<Music>(model);

            Music response = await _musicService.UpdateMusicAsync(id, music);

            if (response == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(Get), response.Id, response);
        }
        /// <summary>
        /// Delete Music for id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] Guid id)
        {
            bool response = await _musicService.DeleteMusicAsync(id);

            if (!response)
            {
                return NotFound();
            }

            return Ok(response);
            
        }


    }
}