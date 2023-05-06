using AutoMapper;
using Main.Application.Models;
using Main.Dto.Product;

namespace Main.MappingConfigurations;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ReverseMap();

        CreateMap<Product, DisplayProductDto>()
            .ReverseMap();
        
        CreateMap<Product, AddProductDto>()
            .ReverseMap();

        CreateMap<UpdateProductDto, Product>()
            .ReverseMap();

        CreateMap<Product, BlockUnblockProductDto>()
            .ReverseMap();
    }
}