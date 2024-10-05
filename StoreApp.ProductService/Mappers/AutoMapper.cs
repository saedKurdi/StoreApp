using AutoMapper;
using StoreApp.ProductService.DTOS;
using StoreApp.ProductService.Entities;

namespace StoreApp.ProductService.Mappers;
public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
