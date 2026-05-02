using WMS.Domain.Enums;

namespace WMS.Domain.Entities;

/// <summary>
/// Task di magazzino (movimento). Macchina a stati: Pending → Active → Completed.
/// </summary>
public sealed class WarehouseTask : BaseEntity
{
    public MovementKind MovementKind { get; private set; }
    public WarehouseTaskState State { get; private set; }
    public int Priority { get; private set; }
    public Guid? ContainerId { get; private set; }
    public Guid? SourceLocationId { get; private set; }
    public Guid? TargetLocationId { get; private set; }

    private WarehouseTask()
    {
    }

    public WarehouseTask(
        MovementKind movementKind,
        int priority,
        Guid? containerId = null,
        Guid? sourceLocationId = null,
        Guid? targetLocationId = null)
    {
        if (priority < 0)
            throw new ArgumentOutOfRangeException(nameof(priority));

        Id = Guid.NewGuid();
        MovementKind = movementKind;
        State = WarehouseTaskState.Pending;
        Priority = priority;
        ContainerId = containerId;
        SourceLocationId = sourceLocationId;
        TargetLocationId = targetLocationId;
    }

    /// <summary>
    /// Avvia un task.
    /// </summary>
    public void Start()
    {
        if (State != WarehouseTaskState.Pending)
            throw new InvalidOperationException("Solo un task Pending può essere avviato.");

        State = WarehouseTaskState.Active;
    }

    /// <summary>
    /// Completa un task.
    /// </summary>
    public void Complete()
    {
        if (State != WarehouseTaskState.Active)
            throw new InvalidOperationException("Solo un task Active può essere completato.");

        State = WarehouseTaskState.Completed;
    }
}
