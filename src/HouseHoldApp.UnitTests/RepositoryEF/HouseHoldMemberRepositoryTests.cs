using System.Collections.Generic;
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
    public class HouseHoldMemberRepositoryTests
    {
        [TestCase]
        public void Add_AddsHouseHoldMemberToDbSet()
        {
            //Arrange
            Mock<DbSet<HouseHoldMember>> dbSet = new Mock<DbSet<HouseHoldMember>>();
            IHouseHoldMemberRepository houseHoldMemberRepository = new HouseHoldMemberRepositoryEF(dbSet.Object);
            HouseHoldMember houseHoldMember = HouseHoldMemberObjectMother.GetHouseHoldMemberWithRandomId();
            //Act
            houseHoldMemberRepository.Add(houseHoldMember);
            //Assert
            dbSet.Verify(d => d.Add(houseHoldMember), Times.Once);
        }

        [TestCase]
        public void GetByUserId_ReturnsCorrectHouseHoldMember_WithUserIdInCollection()
        {
            //Arrange
            IQueryable<HouseHoldMember> houseHoldMembers = HouseHoldMemberObjectMother.CreateList(5).AsQueryable();
            Mock<IDbSet<HouseHoldMember>> dbSet = MockUtil.CreateMockSet(houseHoldMembers);
            IHouseHoldMemberRepository houseHoldMemberRepository = new HouseHoldMemberRepositoryEF(dbSet.Object);
            //Act
            HouseHoldMember houseHoldMember = houseHoldMemberRepository.GetByUserId(houseHoldMembers.First().UserId);
            //Assert
            Assert.True(houseHoldMember == houseHoldMembers.First());
        }
    }
}