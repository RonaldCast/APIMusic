using Moq;
using Services.PersonService;
using System;
using System.Collections.Generic;
using System.Text;
using XUnitTest.Stub;

namespace XUnitTest.MockSetting
{
    public class PersonMock
    {
        public Mock<IPersonService> _personMock {get; set;}

        public PersonMock()
        {
            _personMock = new Mock<IPersonService>();
            Setup();
        }

        private void Setup()
        {
            _personMock.Setup(x => x.GetPersonAsync(Guid.NewGuid())).ReturnsAsync(PersonStub.user);
        }
    }
}
