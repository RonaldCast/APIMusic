using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.ServicesStub
{
    public static class ArtistStub
    {

        public static Artist Artist = new Artist()
        {
            NameArtist = "Barak",
            Country = "RD",
            Gender = "M"
        };

        public static Artist UpdateArtist = new Artist()
        {
            NameArtist = "Barak",
            Country = "USA",
            Gender = "M"
        };

        public static List<Artist> ListArtist = new List<Artist>()
        {
             new Artist(){ NameArtist = "Barak", Country = "USA", Gender = "M"},
             new Artist(){ NameArtist = "Samanta", Country = "RD", Gender = "F"},
             new Artist(){ NameArtist = "El Mayor", Country = "Haiti", Gender = "F"},
             new Artist(){ NameArtist = "Marcos Vidal", Country = "Colombiano", Gender = "M"},
        };
    } 

 }

