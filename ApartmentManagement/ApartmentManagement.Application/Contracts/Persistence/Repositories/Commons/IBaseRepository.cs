using ApartmentManagement.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Contracts.Persistence.Repositories.Commons
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
       

        #region Select

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate = null,params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id);

        #endregion

        #region Insert

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        #endregion

        #region Update

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);

        #endregion

        #region Delete

        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);

        #endregion

     

    }
}
