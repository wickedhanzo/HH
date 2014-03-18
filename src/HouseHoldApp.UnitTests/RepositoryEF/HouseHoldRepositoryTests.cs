using System.Data.Entity;
using System.Linq;
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

        [TestCase]
        public void GetById_ReturnsCorrectHouseHold_WitIdInCollection()
        {
            //Arrange
            IQueryable<HouseHold> houseHolds = HouseHoldObjectMother.CreateList(5).AsQueryable();
            Mock<IDbSet<HouseHold>> dbSet = MockUtil.CreateMockSet(houseHolds);
            IHouseHoldRepository houseHoldRepository = new HouseHoldRepositoryEF(dbSet.Object);
            //Act
            HouseHold houseHold = houseHoldRepository.GetById(houseHolds.First().Id, h => h.HouseHoldMembers);
            //Assert
            Assert.True(houseHold == houseHolds.First() &&
                        houseHold.HouseHoldMembers.Count == 5);
        }
    }
}
