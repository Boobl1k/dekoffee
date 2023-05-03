using AutoMapper;
using Main.Application.Models;
using Main.Dto.Order;

namespace Main.MappingConfigurations;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.Address, opt => opt.Ignore())
            .ForMember(dest => dest.Courier, opt => opt.Ignore())
            .ForMember(dest => dest.Products, opt => opt.Ignore());

        CreateMap<Order, DisplayOrderDto>()
            .ForMember(dest => dest.CourierName,
                opt => opt.MapFrom(src => src.Courier == null ? "-" : src.Courier.Name))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => Order.GetStatusString(src.Status)))
            .ForMember(dest => dest.FullAddress,
                opt => opt.MapFrom(src => src.Address.ToString()))
            .ForMember(dest => dest.Products,
                opt => opt.MapFrom(src => src.Products))
            .ReverseMap();

        CreateMap<UpdateOrderStatusDto, Order>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => (OrderStatus)src.OrderStatus))
            .ReverseMap();
    }
}