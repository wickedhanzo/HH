using System;
using System.Data.Entity;
using System.Linq;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.RepositoryEF.Repositories
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly IDbSet<User> _dbSet;

        public UserRepositoryEF(IDbSet<User> dbSet)
        {
            _dbSet = dbSet;
        }

        public void Add(User user)
        {
            _dbSet.Add(user);
        }

        public User FindByEmailAddress(string emailAddress)
        {
            return _dbSet.FirstOrDefault(u => string.Compare(u.EmailAddress, emailAddress,  StringComparison.OrdinalIgnoreCase) == 0);
        }
    }
}
