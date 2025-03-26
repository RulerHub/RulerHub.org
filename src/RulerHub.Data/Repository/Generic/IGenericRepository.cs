using System.Linq.Expressions;

namespace RulerHub.Data.Repository.Generic;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null);
    Task<T> Create(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(T entity);
}
