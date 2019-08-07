using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using NSwag.Annotations;
using Services.ArtistService;

namespace ApiMusic.Controllers
{
    [SwaggerTag("Artist endPoint",
     AddToDocument = true,
     Description = "This endpoint has a verity of the data about artist",
     DocumentationDescription = "It has repository in Github",
     DocumentationUrl = "https://github.com/RonaldCast/APIMusic/network")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistController(IMapper mapper, IArtistService artistService)
        {
            _artistService = artistService;
        }



        /// <summary>
        /// Return list of artist
        /// </summary>
        /// <returns></returns>
        //GET api/artist/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Artist>>> GetAll()
        {
            IEnumerable<Artist> response = await _artistService.GetAllArtistAsync();

            return Ok(response); 
        }

        //GET api/artist/:id
        /// <summary>
        ///  Get artist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        //POST api/artist/
        /// <summary>
        /// Create Artist 
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        //PUT api/artist/:id
        /// <summary>
        /// Update artist information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
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