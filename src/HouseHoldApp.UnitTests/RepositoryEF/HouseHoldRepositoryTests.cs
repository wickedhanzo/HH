using System.Data.Entity;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.RepositoryEF.Repositories;
using HouseHoldApp.TestBase.ObjectMothers;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.RepositoryEF
{
    [TestFixture]
    public class HouseHoldRepositoryTests
    {
        [TestCase]
        public void Add_AddsHouseHoldToDbSet()
        {
            //Arrange
            Mock<DbSet<HouseHold>> dbSet = new Mock<DbSet<HouseHold>>();
            IHouseHoldRepository houseHoldRepository = new HouseHoldRepositoryEF(dbSet.Object);
            HouseHold houseHold = HouseHoldObjectMother.GetHouseHoldWithRandomId();
            //Act
            houseHoldRepository.Add(houseHold);
            //Assert
            dbSet.Verify(d => d.Add(houseHold), Times.Once);
        }
    }
}
