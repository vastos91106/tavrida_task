using System.Linq.Expressions;

namespace Core.TavridaTask.Interfaces.Repositories;

public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
{
    public Task InsertManyAsync(List<TEntity> entities, CancellationToken cancellationToken);

    public Task SaveAsync(CancellationToken cancellationToken);

    public Task<List<TEntity>> AllWhereAsync(CancellationToken cancellationToken,
        Expression<Func<TEntity, dynamic>>? navigationPropertyPath = null,
        Expression<Func<TEntity, bool>>? filter = null);
}