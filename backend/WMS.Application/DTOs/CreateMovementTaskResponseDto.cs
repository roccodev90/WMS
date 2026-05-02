using WMS.Domain.Enums;

namespace WMS.Application.DTOs;

/// <summary>
/// DTO per la risposta di creazione di un task di movimento.
/// </summary>
public sealed record CreateMovementTaskResponseDto(
    Guid Id,
    MovementKind MovementKind,
    WarehouseTaskState State,
    int Priority,
    Guid? ContainerId,
    Guid? SourceLocationId,
    Guid? TargetLocationId);
