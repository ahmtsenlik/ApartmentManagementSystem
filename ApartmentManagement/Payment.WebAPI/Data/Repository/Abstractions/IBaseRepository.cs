using Payment.WebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Payment.WebAPI.Data.Repository.Abstractions
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T document);
        Task<T> FindByIdAsync(Guid id);
        Task RemoveByIdAsync(Guid id);      
        Task Update(T entity);
    }
}
