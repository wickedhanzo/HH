using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.TestBase.ObjectMothers;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.Domain.DomainServices
{   
    public class HouseHoldServiceTests
    {
        private Mock<IHouseHoldRepository> _houseHoldRepository;
        [TestCase]
        public void CreateHouseHold_CallsAddOnHouseHoldRepository()
        {
            //Arrange
            IHouseHoldService houseHoldService = CreateInstance();
            HouseHold houseHold = HouseHoldObjectMother.GetHouseHoldWithRandomId();
            //Act
            houseHoldService.CreateHouseHold(houseHold);
            //Assert
            _houseHoldRepository.Verify(h => h.Add(houseHold), Times.Once);
        }

        [TestCase]
        public void GetById_ReturnsSameHouseHoldAsRepository()
        {
            //Arrange
            IHouseHoldService houseHoldService = CreateInstance();
            var expected = HouseHoldObjectMother.GetHouseHoldWithRandomId();
            _houseHoldRepository.Setup(h => h.GetById(expected.Id)).Returns(expected);
            //Act
            var actual =houseHoldService.GetById(expected.Id);
            //Assert
            Assert.True(expected.Equals(actual));
        }

        private IHouseHoldService CreateInstance()
        {
            _houseHoldRepository = new Mock<IHouseHoldRepository>();
            IHouseHoldService houseHoldService = new HouseHoldService(_houseHoldRepository.Object);
            return houseHoldService;
        }
    }
}
