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
using Services.PersonService;

namespace ApiMusic.Controllers
{

    [SwaggerTag("Person endPoint",
        AddToDocument = true,
        Description = "This endpoint has a verity of the date about de person",
        DocumentationDescription = "It has repository in Github",
        DocumentationUrl = "https://github.com/RonaldCast/APIMusic/network")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        /// <summary>
        /// Endpoint get person data 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="404"> the user not found</response>
        /// <response code="200">User found</response>
        /// <returns></returns>
        // Get person/:id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserPersonDTO>> Get([FromRoute] Guid id)
        {
            UserPersonDTO userPerson = await _personService.GetPersonAsync(id);
            if (userPerson != null)
            {
                return Ok(userPerson);
            }

            return NotFound(new { message = "User not found" });
        }


        // POST person/
        /// <summary>
        /// Endpoint Create person en account user
        /// </summary>
        /// <param name="person"></param>
        /// <reponse code="200"></reponse>
        /// <response code="500">Unauthorized. Internal server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public  async Task<ActionResult<UserPersonDTO>> Post([FromBody] UserPersonSigninDTO person)
        {
            Person newPerson = _mapper.Map<Person>(person);
            User user = _mapper.Map<User>(person);
            newPerson.User = user;
            var reponse =  await _personService.InsertPersonAsync(newPerson);
            if (reponse != null)
            {
                return Ok(new { data = reponse, message= "The user was created correctly" });
            }

            return StatusCode(500, new { message = "Internal server Error" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        // PUT: person/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDTO>> Put([FromRoute] Guid id,[FromBody] PersonDTO person)
        {
            Person model = _mapper.Map<Person>(person);
            PersonDTO personUpdate = await  _personService.UpdatePersonAsync(id, model);
            if (personUpdate == null)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(201, personUpdate);
            }
             
        }
    }
}