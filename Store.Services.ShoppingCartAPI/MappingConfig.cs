using AutoMapper;
using Store.Services.ProductAPI.Models.Dto;
using Store.Services.ShoppingCartAPI.Models;

namespace Store.Services.ShoppingCartAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDto, Product>().ReverseMap();
            config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            config.CreateMap<Cart, CartDto>().ReverseMap();
        });
        return mappingConfig;
    }
}