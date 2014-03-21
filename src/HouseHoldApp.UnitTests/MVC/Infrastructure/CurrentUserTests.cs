using System;
using System.Security.Claims;
using System.Security.Principal;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.MVC.Infrastructure;
using HouseHoldApp.TestBase.ObjectMothers;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Infrastructure
{
    [TestFixture]
    public class CurrentUserTests
    {
        private Mock<ISessionStorage> _sessionHelper;
        private Mock<IHouseHoldMemberService> _houseHoldMemberService;
        private IIdentity _identity;
        private HouseHoldMember _houseHoldMember;

        [TestCase]
        public void Constructor_SetsProperties_SessionHelperHouseHoldIdIsNotNull()
        {
            //Arrange
            Setup();
            _sessionHelper.Setup(s => s.HouseHoldId).Returns(_houseHoldMember.HouseHoldId);
            //Act
            CurrentUser currentUser = new CurrentUser(_identity, _houseHoldMemberService.Object, _sessionHelper.Object);
            //Assert
            Assert.True(currentUser.IsAuthenticated == _identity.IsAuthenticated);
            Assert.True(currentUser.UserId == _identity.GetUserId());
            Assert.True(currentUser.UserName == _identity.GetUserName());
            Assert.True(currentUser.HouseHoldId == _houseHoldMember.HouseHoldId);
            Assert.True(currentUser.HasHouseHold);
        }

        [TestCase]
        public void Constructor_SetsProperties_SessionHelperHouseHoldIdIsNull()
        {
            Setup();
            _sessionHelper.Setup(s => s.HouseHoldId).Returns((int?)null);

            CurrentUser currentUser = new CurrentUser(_identity, _houseHoldMemberService.Object, _sessionHelper.Object);
            Assert.True(currentUser.IsAuthenticated == _identity.IsAuthenticated
                         && currentUser.UserId == _identity.GetUserId()
                         && currentUser.UserName == _identity.GetUserName()
                         && currentUser.HouseHoldId == _houseHoldMember.HouseHoldId
                         && currentUser.HasHouseHold);
        }

        [TestCase]
        public void Constructor_SetsProperties_SessionHelperHouseHoldIdIsNullAndHouseHoldMemberServiceReturnsNull()
        {
            Setup();
            _sessionHelper.Setup(s => s.HouseHoldId).Returns((int?)null);
            _houseHoldMemberService.Setup(h => h.GetByUserId(_identity.GetUserId())).Returns((HouseHoldMember)null);
            CurrentUser currentUser = new CurrentUser(_identity, _houseHoldMemberService.Object, _sessionHelper.Object);
            Assert.True(currentUser.IsAuthenticated == _identity.IsAuthenticated
                         && currentUser.UserId == _identity.GetUserId()
                         && currentUser.UserName == _identity.GetUserName()
                         && currentUser.HouseHoldId == null
                         && currentUser.HasHouseHold == false);
        }

        private void Setup()
        {
            _houseHoldMemberService = new Mock<IHouseHoldMemberService>();
            _sessionHelper = new Mock<ISessionStorage>();
            _houseHoldMember = HouseHoldMemberObjectMother.GetHouseHoldMemberWithRandomId();
            _sessionHelper.Setup(s => s.HouseHoldId).Returns((int?)null);
            _identity = new ClaimsIdentity("IdentityUserName");
            _houseHoldMemberService.Setup(h => h.GetByUserId(_identity.GetUserId())).Returns(_houseHoldMember);
        }
    }
}
