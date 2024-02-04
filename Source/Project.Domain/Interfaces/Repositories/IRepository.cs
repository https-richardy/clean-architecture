using System.Linq.Expressions;
using Project.Domain.Entities;

namespace Project.Domain.Contracts;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task SaveAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);

    Task<TEntity> RetrieveByIdAsync(int id);
    Task<TEntity> RetrieveAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAllAsync();
}