using MediatR;
using WMS.Application.DTOs;

namespace WMS.Application.Features.WarehouseTasks.Queries.GetWarehouseTaskById;

/// <summary>
/// Query per ottenere un task di magazzino per ID.
/// </summary>
public sealed record GetWarehouseTaskByIdQuery(Guid Id) : IRequest<WarehouseTaskDto?>;
