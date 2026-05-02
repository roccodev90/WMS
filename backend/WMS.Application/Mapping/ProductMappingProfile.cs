using AutoMapper;
using WMS.Application.DTOs;
using WMS.Domain.Entities;

namespace WMS.Application.Mapping;

public sealed class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
