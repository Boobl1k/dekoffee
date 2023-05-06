using AutoMapper;
using Main.Application.Models;
using Main.Dto.Address;

namespace Main.MappingConfigurations;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressDto>()
            .ReverseMap();

        CreateMap<Address, DisplayAddressDto>()
            .ReverseMap();

        CreateMap<Address, AddAddressDto>()
            .ReverseMap();

        CreateMap<UpdateAddressDto, Address>()
            .ReverseMap();
    }
}