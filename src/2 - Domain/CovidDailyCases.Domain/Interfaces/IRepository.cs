using System.Linq.Expressions;
using CovidDailyCases.Domain.Models;

namespace CovidDailyCases.Domain.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Add(TEntity entity);
    Task<TEntity> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    Task Refresh(TEntity entity);
    Task Remove(Guid id);
    Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}