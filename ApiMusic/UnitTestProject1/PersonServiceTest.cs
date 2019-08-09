using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services.PersonService;
using UnitTest;
using FluentAssertions;
using System;
using Microsoft.AspNetCore.Mvc;
using DTO;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class PersonServiceTest
    {
        private SqlLifeFake sqlLifeFake;

        [TestInitialize]
        public void Init()
        {
            sqlLifeFake = new SqlLifeFake();
        }

        [TestMethod]
        public void Should_Created_Person_and_User()
        {
            // ARRANGE
            var user = PersonStub.user;

            using (var context = sqlLifeFake.GetDbContext())
            {
                //ACT
                var personService = new PersonService(context);

                var result = personService.InsertPersonAsync(user);

                // ASSERT
                Assert.AreNotEqual(0, result.Result);
                Assert.AreEqual("Ronal", result.Result.Name);
            }
        }

        [TestMethod]
        public void Should_Get_Person_For_Id_Is_Not_Null()
        {
            //ARRAGEN
            var user = PersonStub.user;
            using (var context = sqlLifeFake.GetDbContext())
            {
                //ACT
                var personService = new PersonService(context);
                var person = personService.InsertPersonAsync(user);
                var result = personService.GetPersonAsync(person.Result.Id);

                //ASSERT
                result.Should().NotBeNull();
            }
        }

        [TestMethod]
        public void Should_Update_Person_Get_New_Information()
        {

            //ARRAGEN
            var user = PersonStub.user;
            var updateUser = PersonStub.UpdateUser;

            using(var context = sqlLifeFake.GetDbContext())
            {
                //ACT
                var personService = new PersonService(context);
                var oldInfoPerson = personService.InsertPersonAsync(user);
                var result = personService
                    .UpdatePersonAsync(oldInfoPerson.Result.Id, updateUser);

                //ASSERT
                result.Result.Name.Should().Equals("Samuel");

            }
        }
    }
}
