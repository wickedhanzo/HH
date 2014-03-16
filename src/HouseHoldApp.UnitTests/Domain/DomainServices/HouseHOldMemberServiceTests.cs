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
        private Mock<IHouseHoldMemberRepository> _houseHoldMemberRepository;
        [TestCase]
        public void CreateHouseHoldMember_CallsAddOnHouseHoldMemberRepository()
        {
            //Arrange
            IHouseHoldMemberService houseHoldMemberService = CreateInstance();
            HouseHoldMember houseHoldMember = HouseHoldMemberObjectMother.GetHouseHoldMemberWithRandomId();
            //Act
            houseHoldMemberService.CreateHouseHoldMember(houseHoldMember);
            //Assert
            _houseHoldMemberRepository.Verify(h => h.Add(houseHoldMember), Times.Once);
        }

        [TestCase]
        public void GetByUserId_ReturnsHouseHoldMemberReturnedByRepository()
        {
            //Arrange
            IHouseHoldMemberService houseHoldMemberService = CreateInstance();
            HouseHoldMember expected = HouseHoldMemberObjectMother.GetHouseHoldMemberWithRandomId();
            _houseHoldMemberRepository.Setup(h => h.GetByUserId("userid")).Returns(expected);
            //Act
            HouseHoldMember actual = houseHoldMemberService.GetByUserId("userid");
            //Assert
            Assert.True(actual.Equals(expected));
        }

        public IHouseHoldMemberService CreateInstance()
        {
            _houseHoldMemberRepository = new Mock<IHouseHoldMemberRepository>();
            IHouseHoldMemberService houseHoldMemberService = new HouseHoldMemberService(_houseHoldMemberRepository.Object);
            return houseHoldMemberService;
        }
    }
}
