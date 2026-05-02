using WMS.Domain.Enums;

namespace WMS.Application.DTOs;

/// <summary>
/// DTO per il task di magazzino.
/// </summary>
public sealed record WarehouseTaskDto(
    Guid Id,
    MovementKind MovementKind,
    WarehouseTaskState State,
    int Priority,
    Guid? ContainerId,
    Guid? SourceLocationId,
    Guid? TargetLocationId);
