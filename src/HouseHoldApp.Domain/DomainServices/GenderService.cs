using System.Collections.Generic;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.Domain.DomainServices
{
    public interface IGenderService
    {
        IEnumerable<Gender> GetAll();
    }
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository houseHoldMemberRepository)
        {
            _genderRepository = houseHoldMemberRepository;
        }
        public IEnumerable<Gender> GetAll()
        {
            return _genderRepository.GetAll();
        }
    }
}
