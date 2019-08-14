using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PlayListInfoDTO
    {
  
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Music> musics { get; set; }
    }
}
