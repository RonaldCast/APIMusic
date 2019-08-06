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
        }
    }
}
