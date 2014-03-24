using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HouseHoldApp.Domain.Entities;

namespace HouseHoldApp.RepositoryEF.Repositories
{
    public abstract class RepositoryEF<T> where T : EntityBase
    {
        private readonly IDbSet<T> _dbSet;

        public RepositoryEF(IDbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id, params Expression<Func<T, object>>[] includeFields)
        {

            IQueryable<T> dbSet = _dbSet;
            foreach (Expression<Func<T, object>> includeField in includeFields)
                dbSet = dbSet.Include<T, object>(includeField);

            return dbSet.FirstOrDefault(e => e.Id == id);
        }
    }
}
