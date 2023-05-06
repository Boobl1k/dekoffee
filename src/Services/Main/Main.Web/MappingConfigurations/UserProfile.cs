using AutoMapper;
using Main.Application.Models;
using Main.Dto.User;

namespace Main.MappingConfigurations;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, LoginUserDto>()
            .ReverseMap();

        CreateMap<User, RegisterUserDto>()
            .ReverseMap();

        CreateMap<User, ProfileDto>()
            .ReverseMap();

        CreateMap<User, UpdateProfileDto>()
            .ReverseMap();

        CreateMap<User, BlockUnblockUserDto>()
            .ReverseMap();

        CreateMap<User, DisplayUserDto>()
            .ReverseMap();
    }
}