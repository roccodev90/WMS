using AutoMapper;
using WCS.Application.DTOs;
using WCS.Domain.Entities;

namespace WCS.Application.Mapping;

public sealed class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
