using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RulerHub.Data.Repository.Generic;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null );
    Task<T> Create( T entity );
    Task<bool> Update( T entity );
    Task<bool> Delete( T entity );
}
