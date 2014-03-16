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

        [TestCase]
        public void Constructor_SetsProperties_SessionHelperHouseHoldIdIsNotNull()
        {
            Mock<IHouseHoldMemberService> houseHoldMemberService = new Mock<IHouseHoldMemberService>();
            Mock<ISessionHelper> sessionHelper = new Mock<ISessionHelper>();
            
            HouseHoldMember houseHoldMember = HouseHoldMemberObjectMother.GetHouseHoldMemberWithRandomId();
            sessionHelper.Setup(s => s.HouseHoldId).Returns(houseHoldMember.HouseHoldId);
            IIdentity identity = new ClaimsIdentity("IdentityUserName");
            CurrentUser currentUser = new CurrentUser(identity, houseHoldMemberService.Object, sessionHelper.Object);
            Assert.True(currentUser.IsAuthenticated == identity.IsAuthenticated
                         && currentUser.UserId == identity.GetUserId()
                         && currentUser.UserName == identity.GetUserName()
                         && currentUser.HouseHoldId == houseHoldMember.HouseHoldId);
        }

        [TestCase]
        public void Constructor_SetsProperties_SessionHelperHouseHoldIdIsNull()
        {
            Mock<IHouseHoldMemberService> houseHoldMemberService = new Mock<IHouseHoldMemberService>();
            Mock<ISessionHelper> sessionHelper = new Mock<ISessionHelper>();

            HouseHoldMember houseHoldMember = HouseHoldMemberObjectMother.GetHouseHoldMemberWithRandomId();
            sessionHelper.Setup(s => s.HouseHoldId).Returns((int?) null);
            IIdentity identity = new ClaimsIdentity("IdentityUserName");
            houseHoldMemberService.Setup(h => h.GetByUserId(identity.GetUserId())).Returns(houseHoldMember);
            CurrentUser currentUser = new CurrentUser(identity, houseHoldMemberService.Object, sessionHelper.Object);
            Assert.True(currentUser.IsAuthenticated == identity.IsAuthenticated
                         && currentUser.UserId == identity.GetUserId()
                         && currentUser.UserName == identity.GetUserName()
                         && currentUser.HouseHoldId == houseHoldMember.HouseHoldId);
        }
    }
}
