using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Person, UserPersonSigninDTO>()
                .ReverseMap();
            CreateMap<User, UserPersonSigninDTO>()
                .ReverseMap();

            CreateMap<Person, PersonDTO>()
                .ReverseMap();

            CreateMap<Artist, ArtistDTO>()
                .ReverseMap();

            CreateMap<Album, AlbumDTO>()
                .ReverseMap();

            CreateMap<Music, MusicDTO>()
                .ReverseMap();

            CreateMap<Music, MusicBasicInfoDTO>()
               .ReverseMap();
        }
    }
}
