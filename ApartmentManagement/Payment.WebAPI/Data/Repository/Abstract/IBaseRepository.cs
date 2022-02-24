using Payment.WebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.WebAPI.Data.Repository.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T GetById(Guid id);
        void Remove(Guid id);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
