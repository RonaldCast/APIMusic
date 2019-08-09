using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
   public static class AuthStub
    {
        public static UserDTO user = new UserDTO()
        {
            Email = "ronald123@gmail.com",
            Password = "123456"
        };
    }
}
