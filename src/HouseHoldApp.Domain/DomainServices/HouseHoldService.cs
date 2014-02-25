using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.Domain.DomainServices
{
    public interface IHouseHoldService
    {
        void CreateHouseHold(HouseHold houseHold);
    }

    public class HouseHoldService : IHouseHoldService
    {
        private IHouseHoldRepository _houseHoldRepository;

        public HouseHoldService(IHouseHoldRepository houseHoldRepository)
        {
            _houseHoldRepository = houseHoldRepository;
        }
        public void CreateHouseHold(HouseHold houseHold)
        {
            _houseHoldRepository.Add(houseHold);
        }
    }
}
