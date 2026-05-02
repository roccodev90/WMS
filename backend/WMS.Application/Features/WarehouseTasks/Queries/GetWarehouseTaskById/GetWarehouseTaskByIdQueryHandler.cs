using AutoMapper;
using MediatR;
using WMS.Application.DTOs;
using WMS.Domain.Entities;
using WMS.Domain.Interfaces;

namespace WMS.Application.Features.WarehouseTasks.Queries.GetWarehouseTaskById;

/// <summary>
/// Handler per la query per ottenere un task di magazzino per ID.
/// </summary>
public sealed class GetWarehouseTaskByIdQueryHandler : IRequestHandler<GetWarehouseTaskByIdQuery, WarehouseTaskDto?>
{
    private readonly IMapper _mapper;
    private readonly IRepository<WarehouseTask> _repository;

    public GetWarehouseTaskByIdQueryHandler(IRepository<WarehouseTask> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handle per la query per ottenere un task di magazzino per ID.
    /// </summary>
    /// <param name="request">La query per ottenere un task di magazzino per ID.</param>
    /// <param name="cancellationToken">Il token di cancellazione.</param>
    /// <returns>Il task di magazzino per ID.</returns>
    public async Task<WarehouseTaskDto?> Handle(GetWarehouseTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return entity is null ? null : _mapper.Map<WarehouseTaskDto>(entity);
    }
}
