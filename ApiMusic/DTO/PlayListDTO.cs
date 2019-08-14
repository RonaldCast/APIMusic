using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class PlayListDTO
    {
       
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }
        [Required]
        [MaxLength(75)]
        public string Description { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
