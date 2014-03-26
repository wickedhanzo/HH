using System.Data.Entity;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.RepositoryEF.Repositories
{
    public class GenderRepositoryEF : RepositoryEF<Gender>, IGenderRepository
    {
        public GenderRepositoryEF(IDbSet<Gender> dbSet) : base(dbSet)
        {
        }
    }
}
