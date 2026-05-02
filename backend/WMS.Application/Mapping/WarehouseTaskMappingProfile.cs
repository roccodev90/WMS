using AutoMapper;
using WMS.Application.DTOs;
using WMS.Domain.Entities;

namespace WMS.Application.Mapping;

/// <summary>
/// Mapping per il task di magazzino.
/// </summary>
public sealed class WarehouseTaskMappingProfile : Profile
{
    public WarehouseTaskMappingProfile()
    {
        CreateMap<WarehouseTask, WarehouseTaskDto>();
    }
}
