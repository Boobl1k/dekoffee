using AutoMapper;
using Main.Application.Models;
using Main.Dto.User;

namespace Main.MappingConfigurations;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, RegisterUserDto>()
            .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
        
        CreateMap<User, ProfileDto>()
            .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();

        CreateMap<User, UpdateProfileDto>()
            .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
    }
}