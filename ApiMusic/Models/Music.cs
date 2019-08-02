using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Music
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public DateTimeOffset DatePublic { get; set; }
        public Album Album { get; set; }

        public ICollection<Artist> Artists { get; set; } 
        public ICollection<PlayList> PlayLists { get; set; }
       
    }
}
