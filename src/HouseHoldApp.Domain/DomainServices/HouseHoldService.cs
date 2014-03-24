using System.Collections.Generic;
using System.Linq;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.Domain.DomainServices
{
    public interface IHouseHoldService
    {
        void CreateHouseHold(HouseHold houseHold);
        HouseHold GetById(int houseHoldId);

        IEnumerable<HouseHold> GetAll();
    }

    public class HouseHoldService : IHouseHoldService
    {
        private readonly IHouseHoldRepository _houseHoldRepository;

        public HouseHoldService(IHouseHoldRepository houseHoldRepository)
        {
            _houseHoldRepository = houseHoldRepository;
        }
        public void CreateHouseHold(HouseHold houseHold)
        {
            _houseHoldRepository.Add(houseHold);
        }

        public HouseHold GetById(int houseHoldId)
        {
           return _houseHoldRepository.GetById(houseHoldId,
               h => h.HouseHoldMembers,
               h => h.HouseHoldMembers.Select(hm => hm.User));
        }

        public IEnumerable<HouseHold> GetAll()
        {
            return _houseHoldRepository.GetAll();
        }
    }
}
