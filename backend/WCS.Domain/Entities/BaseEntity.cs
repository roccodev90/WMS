namespace WCS.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    protected BaseEntity()
    {
    }

    protected BaseEntity(Guid id) => Id = id;
}
