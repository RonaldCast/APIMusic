using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class MusicDTO
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MaxLength(7)]
        public string Duration { get; set; }
        public DateTimeOffset DatePublic { get; set; }
        [Required]
        public Guid AlbumId { get; set; }
        [Required]
        public List<MusicArtist> MusicArtists { get; set; }

    }
}
