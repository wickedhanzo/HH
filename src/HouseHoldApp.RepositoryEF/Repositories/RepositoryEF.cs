using System.Data.Entity;
using System.Linq;
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

        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(e => e.Id == id);
        }
    }
}
