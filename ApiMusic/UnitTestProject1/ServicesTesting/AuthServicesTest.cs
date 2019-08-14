using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.AuthServices;
using Services.PersonService;

namespace UnitTest.ServicesTesting
{
    [TestClass]
    public class AuthServicesTest
    {
        private SqlLifeFake _sqlLifeFake;
        [TestInitialize]
        public void Init()
        {
            _sqlLifeFake = new SqlLifeFake();
        }

       [TestMethod]
        public void Should_Login_User()
        {
            //ARRANGE
            var person = PersonStub.user;
            var user = AuthStub.user;

            using (var context = _sqlLifeFake.GetDbContext())
            {
                PersonService personService = new PersonService(context);
                AuthService authService = new AuthService(context);

                //ACT
                var personRegistre = personService.InsertPersonAsync(person);
                var result = authService.LoginUserAsync(user);

                //ASSERT
                result.Result.Should().NotBeNull();

            }
        } 
    }
}
