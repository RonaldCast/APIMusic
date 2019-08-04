using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class MusicDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public DateTimeOffset DatePublic { get; set; }
        public Guid AlbumId { get; set; }

    }
}
