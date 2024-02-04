using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Contracts;
using Project.Domain.Entities;

namespace Project.Infra.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly AppDbContext _dbContext;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    # pragma warning disable CS8603
    public virtual async Task<TEntity> RetrieveAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<TEntity> RetrieveByIdAsync(int id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task SaveAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        var existingEntity = await _dbContext.Set<TEntity>().FindAsync(entity.Id);

        if (existingEntity != null)
        {
            _dbContext.Entry(existingEntity).State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
        }

        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}