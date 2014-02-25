using System.Data.Entity;

namespace HouseHoldApp.RepositoryEF.Repositories
{
    public abstract class RepositoryEF<T> where T : class
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
    }
}
