using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly TmitterDbContext _context;

    public Repository(TmitterDbContext context)
    {
        _context = context;
    }
    public virtual IQueryable<T> AsQueryable() => _context.Set<T>().AsQueryable();

    // Add methods
    public virtual async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual T Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual async Task AddRangeAsync(List<T> entity)
    {
        await _context.Set<T>().AddRangeAsync(entity);
        await _context.SaveChangesAsync();
    }


    // Update methods
    public virtual T Update(T entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        _context.Attach(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }

    public virtual void UpdateRange(List<T> entities)
    {
        foreach (var entity in entities)
        {
            _context.Attach(entity).State = EntityState.Modified;
        }

        _context.SaveChanges();
    }

    // Delete method
    public virtual bool Delete(Guid id)
    {
        var data = _context.Set<T>().FirstOrDefault(x => x.Id == id);

        if (data is null)
            return false;

        _context.Set<T>().Remove(data);
        _context.SaveChanges();
        return true;
    }

    // Get list methods
    public virtual Task<List<T>> GetAllAsync()
    {
        return _context.Set<T>().ToListAsync();
    }

    public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
    {
        IQueryable<T> query = _context.Set<T>();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (orderBy is not null)
        {
            query = orderBy(query);
        }

        return await query.ToListAsync();
    }

    public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (orderBy is not null)
        {
            query = orderBy(query);
        }

        return await query.ToListAsync();
    }


    // Get item methods
    public virtual T Get(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    public virtual T Get(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().FirstOrDefault(predicate);
    }

    public virtual async Task<T> GetAsync(Guid id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(predicate);
    }


    // Save methods
    public virtual void SaveChanges()
    {
        _context.SaveChanges();
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}