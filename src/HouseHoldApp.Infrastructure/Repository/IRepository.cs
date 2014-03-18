using System;
using System.Linq.Expressions;

namespace HouseHoldApp.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T GetById(int id, params Expression<Func<T, object>>[] includeFields);
    }
}
