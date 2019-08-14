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
using Services.AlbumService;

namespace ApiMusic.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumService albumService, IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }


        /// <summary>
        /// Get all albums
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> Get()
        {
            IEnumerable<Album> response = await _albumService.GetAlbumsAsync();
            return Ok(response);
        }

        /// <summary>
        /// Get album for id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> Get([FromRoute] Guid id)
        {
            Album album = await _albumService.GetAlbum(id);

            if (album == null)
            {
                return NotFound(new { message = "The album no found"});
            }

            return Ok(album);
        }

        /// <summary>
        /// Create album
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Album>> Post([FromBody] AlbumDTO model)
        {
            Album album = _mapper.Map<Album>(model);
            Album response = await _albumService.InsertAlbumAsync(album);

            if (response == null)
            {
                return BadRequest();
            }

            return  CreatedAtAction(nameof(Get), new { id = response.Id }, response);

        }

        /// <summary>
        /// Update album
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Album>> Put([FromRoute] Guid id ,[FromBody] AlbumDTO model)
        {
            
            Album album = _mapper.Map<Album>(model);
            Album response = await _albumService.UpdateAlbumAsync(id, album);

            if (response == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        /// <summary>
        /// Delete music for id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var response = await _albumService.DeleteAlbumAsync(id);
            if (!response)
            {
                return  BadRequest();
            }
            return Ok(response);
        }
    }
}