using System;
using System.Collections.Generic;

namespace Models
{
    public class PlayList
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public IList<PlayListMusic>  PlayListMusics { get; set; }
    }
}