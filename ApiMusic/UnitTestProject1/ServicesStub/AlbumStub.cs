using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.ServicesStub
{
    public static class AlbumStub
    {
        public static Album Album = new Album()
        {
            Title = "Los Ra",
            Description = "To fuelte",
            DatePublic = DateTimeOffset.Now,
        };

        public static Album UpdateAlbum = new Album()
        {

            Title = "EL final",
            Description = "De los finales con el final",
            DatePublic = DateTimeOffset.Now,
        };

        public static List<Album> Albums = new List<Album>()
        {
            new Album(){

                Title = "EL final",
                Description = "De los finales con el final",
                DatePublic = DateTimeOffset.Now,
            },

             new Album(){

                Title = "La independendicia",
                Description = "Este trata acerca de una coleccion historica",
                DatePublic = DateTimeOffset.Now,
            }
        }; 


    }
}
