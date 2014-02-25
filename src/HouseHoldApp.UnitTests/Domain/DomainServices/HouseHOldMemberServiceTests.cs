using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.TestBase.ObjectMothers;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.Domain.DomainServices
{
    [TestFixture]
    public class HouseHoldMemberServiceTests
    {
        [TestCase]
        public void CreateHouseHoldMember_CallsAddOnHouseHoldMemberRepository()
        {
            //Arrange
            Mock<IHouseHoldMemberRepository> houseHoldMemberRepository = new Mock<IHouseHoldMemberRepository>();
            IHouseHoldMemberService houseHoldMemberService = new HouseHoldMemberService(houseHoldMemberRepository.Object);
            HouseHoldMember houseHoldMember = HouseHoldMemberObjectMother.GetHouseHoldMemberWithRandomId();
            //Act
            houseHoldMemberService.CreateHouseHoldMember(houseHoldMember);
            //Assert
            houseHoldMemberRepository.Verify(h => h.Add(houseHoldMember), Times.Once);
        }
    }
}
