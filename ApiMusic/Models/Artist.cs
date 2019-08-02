using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string NameArtist { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Music> Musics { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

    }
}
