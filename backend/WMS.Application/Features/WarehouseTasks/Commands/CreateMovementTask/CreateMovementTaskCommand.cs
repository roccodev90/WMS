using MediatR;
using WMS.Application.DTOs;
using WMS.Domain.Enums;

namespace WMS.Application.Features.WarehouseTasks.Commands.CreateMovementTask;

/// <summary>
/// Comando per creare un task di movimento.
/// </summary>
public sealed record CreateMovementTaskCommand(
    MovementKind MovementKind,
    int Priority,
    Guid TargetLocationId,
    Guid? SourceLocationId = null,
    Guid? ContainerId = null) : IRequest<CreateMovementTaskResponseDto>;
