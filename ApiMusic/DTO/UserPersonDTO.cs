using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UserPersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
