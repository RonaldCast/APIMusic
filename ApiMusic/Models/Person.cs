using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public User User { get; set; }
    }
}
