using AutoMapper;
using MediatR;
using WMS.Application.Common.Exceptions;
using WMS.Application.DTOs;
using WMS.Domain.Entities;
using WMS.Domain.Interfaces;

namespace WMS.Application.Features.WarehouseTasks.Commands.CreateMovementTask;

/// <summary>
/// Handler per il comando di creazione di un task di movimento.
/// </summary>
public sealed class CreateMovementTaskCommandHandler : IRequestHandler<CreateMovementTaskCommand, CreateMovementTaskResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Location> _locationRepository;
    private readonly IRepository<WarehouseTask> _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWarehouseTaskQueries _warehouseTaskQueries;

    /// <summary>
    /// Crea un nuovo handler per il comando di creazione di un task di movimento.
    /// </summary>
    /// <param name="locationRepository">Il repository delle location.</param>
    /// <param name="taskRepository">Il repository dei task.</param>
    /// <param name="unitOfWork">Il unit of work.</param>
    /// <param name="warehouseTaskQueries">Il repository delle query dei task di magazzino.</param>
    /// <param name="mapper">Il mapper.</param>
    public CreateMovementTaskCommandHandler(
        IRepository<Location> locationRepository,
        IRepository<WarehouseTask> taskRepository,
        IUnitOfWork unitOfWork,
        IWarehouseTaskQueries warehouseTaskQueries,
        IMapper mapper)
    {
        _locationRepository = locationRepository;
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
        _warehouseTaskQueries = warehouseTaskQueries;
        _mapper = mapper;
    }

    /// <summary>
    /// Handle per il comando di creazione di un task di movimento.
    /// </summary>
    /// <param name="request">Il comando di creazione di un task di movimento.</param>
    /// <param name="cancellationToken">Il token di cancellazione.</param>
    /// <returns>La risposta di creazione di un task di movimento.</returns>
    public async Task<CreateMovementTaskResponseDto> Handle(CreateMovementTaskCommand request, CancellationToken cancellationToken)
    {
        var location = await _locationRepository.GetByIdAsync(request.TargetLocationId, cancellationToken);
        if (location is null)
            throw new LocationNotFoundException(request.TargetLocationId);

        var occupied = await _warehouseTaskQueries.HasPendingOrActiveTaskForTargetLocationAsync(
            request.TargetLocationId,
            cancellationToken);

        if (occupied)
            throw new LocationNotFreeException(request.TargetLocationId);

        var task = new WarehouseTask(
            request.MovementKind,
            request.Priority,
            request.ContainerId,
            request.SourceLocationId,
            request.TargetLocationId);

        _taskRepository.Add(task);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CreateMovementTaskResponseDto>(task);
    }
}
