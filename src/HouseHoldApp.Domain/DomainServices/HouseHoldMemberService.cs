using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.Domain.DomainServices
{
    public interface IHouseHoldMemberService
    {
        void CreateHouseHoldMember(HouseHoldMember houseHoldMember);

        HouseHoldMember GetByUserId(string userId);
    }

    public class HouseHoldMemberService : IHouseHoldMemberService
    {
        private readonly IHouseHoldMemberRepository _houseHoldMemberRepository;

        public HouseHoldMemberService(IHouseHoldMemberRepository houseHoldMemberRepository)
        {
            _houseHoldMemberRepository = houseHoldMemberRepository;
        }
        public void CreateHouseHoldMember(HouseHoldMember houseHoldMember)
        {
            _houseHoldMemberRepository.Add(houseHoldMember);
        }

        public HouseHoldMember GetByUserId(string userId)
        {
            return _houseHoldMemberRepository.GetByUserId(userId);
        }
    }
}
