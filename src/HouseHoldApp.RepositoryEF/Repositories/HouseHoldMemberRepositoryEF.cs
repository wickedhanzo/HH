using System.Data.Entity;
using System.Linq;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.RepositoryEF.Repositories
{
    public class HouseHoldMemberRepositoryEF : RepositoryEF<HouseHoldMember>, IHouseHoldMemberRepository
    {
        private readonly IDbSet<HouseHoldMember> _dbSet;

        public HouseHoldMemberRepositoryEF(IDbSet<HouseHoldMember> dbSet)
            : base(dbSet)
        {
            _dbSet = dbSet;
        }

        public HouseHoldMember GetByUserId(string userId)
        {
            return _dbSet.SingleOrDefault(hm => hm.UserId == userId);
        }
    }
}

