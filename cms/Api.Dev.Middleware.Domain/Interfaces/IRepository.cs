using Api.Dev.Middleware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dev.Middleware.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GeatAllAsync();

        Task<T> AddAsync(T dbReord);

        Task<T> GetByIdAsync(int id);
        Task<T> GetByNameAsync(Expression<Func<T,bool>> predicate);

        Task<int> DeleteAsync(T dbRecord);

        Task<int> UpdateAsync(T dbReord);
    }
}
