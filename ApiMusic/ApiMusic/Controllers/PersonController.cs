using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Services.PersonService;

namespace ApiMusic.Controllers
{

    [SwaggerTag("Person endPoint",
        AddToDocument = true,
        Description = "This endpoint has a verity of the date about de person",
        DocumentationDescription = "It has repository in Github" ,
        DocumentationUrl = "https://github.com/RonaldCast/APIMusic/network")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService service )
        {
            personService = service;
        }
    }
}