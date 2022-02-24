using ApartmentManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApartmentManagement.Application.Contracts.Persistence.Repositories.Commons
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
       

        #region Select

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate = null,params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id);

        #endregion

        #region Insert

        Task<T> AddAsync(T entity);

        #endregion

        #region Update

        Task UpdateAsync(T entity);

        #endregion

        #region Delete

        Task RemoveAsync(T entity); 

        #endregion

     

    }
}
