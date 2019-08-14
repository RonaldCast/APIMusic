using System;
using System.Collections.Generic;

namespace Services.PlayListService
{
    public class PlayListMusicDTO
    {
        public Guid Id { get; set; }
        public List<Guid> Music { get; set; }
        
    }
}