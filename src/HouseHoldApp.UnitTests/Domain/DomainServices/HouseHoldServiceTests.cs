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
        [TestCase]
        public void CreateHouseHold_CallsAddOnHouseHoldRepository()
        {
            //Arrange
            Mock<IHouseHoldRepository> houseHoldRepository = new Mock<IHouseHoldRepository>();
            IHouseHoldService houseHoldService = new HouseHoldService(houseHoldRepository.Object);
            HouseHold houseHold = HouseHoldObjectMother.GetHouseHoldWithRandomId();
            //Act
            houseHoldService.CreateHouseHold(houseHold);
            //Assert
            houseHoldRepository.Verify(h => h.Add(houseHold), Times.Once);
        }
    }
}
