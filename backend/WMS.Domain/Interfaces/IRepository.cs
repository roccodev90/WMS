using WMS.Domain.Entities;

namespace WMS.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(TEntity entity);
}
