using ApiMusic.Controllers;
using DTO;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Persistent;
using Services.PersonService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{

    public class PersonControllerTest
    {
        private IPersonService _personService;

        public PersonControllerTest()
        {

            _personService = new PersonService();
        }
        //GOOD
        [Fact]
        public async void ShuldReturnActionResultObjet()
        {
            //Arrange
            Guid id = Guid.Parse("98090DA9-5D2B-479C-825B-6F76AFFCEEA0");
            UserPersonDTO user = new UserPersonDTO();
            var mockPerson = new Mock<IPersonService>();
            mockPerson.Setup(p => p.GetPersonAsync(id)).ReturnsAsync(user);
            PersonController personController = new PersonController(mockPerson.Object);
            
            //Act
            var result = await personController.Get(id);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
       

        }

       /* [Fact]
        public async void ShuldGetUserForId()
        {

            Guid id = Guid.Parse("98090DA9-5D2B-479C-825B-6F76AFFCEEA0");
            UserPersonDTO user = new UserPersonDTO() {
                Id = Guid.Parse("98090DA9-5D2B-479C-825B-6F76AFFCEEA0"),
                Name = "Ronald"
            };
            var mockPerson = new Mock<IPersonService>();
            mockPerson.Setup(p => p.GetPersonAsync(id)).ReturnsAsync(user);
            PersonController personController = new PersonController(mockPerson.Object);

            var result = await personController.Get(id);
            result.Value.Name.Should().Be("Ronald");
               
        }*/
        
    }
}
