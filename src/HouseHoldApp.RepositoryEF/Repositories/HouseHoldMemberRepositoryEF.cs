using System.Data.Entity;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.RepositoryEF.Repositories
{
    public class HouseHoldMemberRepositoryEF : RepositoryEF<HouseHoldMember>, IHouseHoldMemberRepository
    {
        public HouseHoldMemberRepositoryEF(IDbSet<HouseHoldMember> dbSet)
            : base(dbSet)
        {
        }
    }
}

