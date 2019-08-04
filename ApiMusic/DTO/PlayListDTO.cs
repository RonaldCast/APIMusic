using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PlayListDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
