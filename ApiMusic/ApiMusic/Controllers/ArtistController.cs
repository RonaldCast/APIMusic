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
using NSwag.Annotations;
using Services.ArtistService;

namespace ApiMusic.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistController(IMapper mapper, IArtistService artistService)
        {
            _artistService = artistService;
            _mapper = mapper;
        }



        /// <summary>
        /// Return list of artist
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //GET api/artist/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> Get()
        {
            IEnumerable<Artist> response = await _artistService.GetAllArtistAsync();

            return Ok(response); 
        }


        /// <summary>
        ///  Get artist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //GET api/artist/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> Get([FromRoute] Guid id)
        {
            Artist artist = await _artistService.GetArtistAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(artist);
            }
        }


        /// <summary>
        /// Create Artist 
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //POST api/artist/
        [HttpPost]
        public async Task<ActionResult<ArtistDTO>> Post(ArtistDTO artist)
        {
            Artist newArtist = _mapper.Map<Artist>(artist);
            ArtistDTO response =  await _artistService.InsertArtistAsync(newArtist);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return CreatedAtAction(nameof(Get), new { id= response.Id}, response);
            }
        }


        /// <summary>
        /// Update artist information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        //PUT api/artist/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Artist>> Put([FromRoute] Guid id, [FromBody] ArtistDTO model)
        {
            Artist artist = _mapper.Map<Artist>(model);

            Artist response = await _artistService.UpdateArtistAsync(id, artist);

            if (response == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }
        

        
    }
}