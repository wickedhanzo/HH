using System.Data.Entity;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.RepositoryEF.Repositories
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepositoryEF(DbSet<User> dbSet)
        {
            _dbSet = dbSet;
        }

        public void Add(User user)
        {
            _dbSet.Add(user);
        }
    }
}
