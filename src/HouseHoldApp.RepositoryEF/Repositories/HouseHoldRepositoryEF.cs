using System.Data.Entity;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.RepositoryEF.Repositories
{
    public class HouseHoldRepositoryEF : RepositoryEF<HouseHold>, IHouseHoldRepository
    {
        public HouseHoldRepositoryEF(IDbSet<HouseHold> dbSet) : base(dbSet)
        {
        }
    }
}
