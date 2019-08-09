using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTest.Stub
{
    public class PersonStub
    {
       public static UserPersonDTO user = new UserPersonDTO()
        {
            Id = Guid.Parse("98090DA9-5D2B-479C-825B-6F76AFFCEEA0"),
            Name = "Ronald",
            LastName = "Castillo"
        };
    }
}
