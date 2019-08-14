using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PlayListMusic
    {
        public Guid PlayListId { get; set; }
        public PlayList PlayList { get; set; }

        public Guid MusicId { get; set; }
        public Music Music { get; set; }
    }
}
