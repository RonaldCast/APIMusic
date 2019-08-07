using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class AlbumDTO
    {

        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public Guid ArtistId { get; set; }
    }
}
