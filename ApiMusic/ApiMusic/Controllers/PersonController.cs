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

        //person/:id
        //[HttpGet("{id}")]


        // POST person/
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

            return NotFound( new { message = "Error inserting data" });
        }
    }
}