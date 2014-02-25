using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.Domain.DomainServices
{
    public interface IHouseHoldMemberService
    {
        void CreateHouseHoldMember(HouseHoldMember houseHoldMember);
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
    }
}
