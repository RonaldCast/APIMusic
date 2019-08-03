using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DatePublic { get; set; }

        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; }

        public ICollection<Music> Musics { get; set; }
    }
}
