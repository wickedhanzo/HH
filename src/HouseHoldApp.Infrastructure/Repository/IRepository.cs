using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HouseHoldApp.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T GetById(int id, params Expression<Func<T, object>>[] includeFields);
        IEnumerable<T> GetAll();
    }
}
