using System;
using System.Data.Entity;
using System.Linq;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.RepositoryEF.Repositories
{
    public class UserRepositoryEF : RepositoryEF<User>, IUserRepository
    {
        private readonly IDbSet<User> _dbSet;

        public UserRepositoryEF(IDbSet<User> dbSet) : base(dbSet)
        {
            _dbSet = dbSet;
        }

        public User FindByEmailAddress(string emailAddress)
        {
            return _dbSet.FirstOrDefault(u => string.Compare(u.EmailAddress, emailAddress,  StringComparison.OrdinalIgnoreCase) == 0);
        }
    }
}
