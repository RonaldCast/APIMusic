using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    public static class PersonStub
    {
       public static Person user = new Person()
        {
            Name = "Ronal",
            LastName = "Castillo",
            Country = "RD",
            Gender = "M",
            User = new User()
            {
                Email = "ronald123@gmail.com",
                Password = "123456"
            }
        };

        public static Person UpdateUser = new Person()
        {
            Name = "Samuel",
            LastName = "Perez",
            Country = "MX",
            Gender = "M",
        };
    }
}
