using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
   public class ArtistDTO
    {

        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string NameArtist { get; set; }

        [Required]
        [MaxLength(30)]
        public string Country { get; set; }

        [Required]
        [MaxLength(1)]
        public string Gender { get; set; }
    }
}
