using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MusicArtist
    {
        public Guid MusicId { get; set; }
        public Music Music { get; set; }

        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
