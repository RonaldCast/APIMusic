using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.ServicesStub
{
    public static class MusicStub
    {
        public static Music Music = new Music()
        {
            Title = "Lolo",
            Duration = "3:52",
            DatePublic = DateTimeOffset.Now,

        };

        public static Music UpdateMusic = new Music()
        {
            Title = "Los angeles",
            Duration = "3:52",
        };

        public static List<Music> Musics = new List<Music>()
        {
          new Music {Title = "Los angeles", Duration = "3:52", DatePublic = DateTimeOffset.Now},
          new Music {Title = "Pero tu", Duration = "5:40", DatePublic = DateTimeOffset.Now},
          new Music {Title = "And your love", Duration = "4:02", DatePublic = DateTimeOffset.Now},

        };
    }
}
