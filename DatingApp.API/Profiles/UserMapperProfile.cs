using DatingApp.API.Data.Entities;
using DatingApp.API.Extensions;
using DatingApp.API.DTOs;
using AutoMapper;

namespace DatingApp.API.Profiles;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<User, MemberDto>()
            .ForMember(dest => dest.Age,
                options => options
                    .MapFrom(src => src.DateOfBirth.CalculateAge()));

        CreateMap<RegisterUserDTO, User>();
    }
}