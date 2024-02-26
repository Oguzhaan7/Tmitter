using System.Linq.Expressions;
using Tmitter.Domain;

namespace Tmitter.Application.Common.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> AsQueryable();

    Task<T> AddAsync(T entity);
    T Add(T entity);
    Task AddRangeAsync(List<T> entity);

    T Update(T entity);
    void UpdateRange(List<T> entities);

    bool Delete(Guid id);

    // Get list of items
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);

    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        params Expression<Func<T, object>>[] includes);

    // Get single item
    T Get(Guid id);
    T Get(Expression<Func<T, bool>> predicate);
    Task<T> GetAsync(Guid id);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

    void SaveChanges();
    Task SaveChangesAsync();
}