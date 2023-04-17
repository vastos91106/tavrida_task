using System.Linq.Expressions;
using Core.TavridaTask.Interfaces.Repositories;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.TavridaTask.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly TavridaTaskDbContext _dbContext;
    private bool _disposed = false;

    public GenericRepository(TavridaTaskDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public Task InsertManyAsync(List<T> entities, CancellationToken cancellationToken)
        => _dbContext.BulkInsertAsync(entities, cancellationToken: cancellationToken);

    public Task SaveAsync(CancellationToken cancellationToken) => _dbContext.SaveChangesAsync(cancellationToken);

    public async Task<List<T>> AllWhereAsync(CancellationToken cancellationToken,
        Expression<Func<T, dynamic>>? navigationPropertyPath = null,
      Expression<Func<T, bool>>? filter = null)
    {
        var query = this._dbContext.Set<T>().AsNoTracking();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (navigationPropertyPath != null)
        {
            query = query.Include(navigationPropertyPath);
        }
        
        return await query.ToListAsync(cancellationToken: cancellationToken);
    }

    private void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}