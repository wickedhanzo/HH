using System.Security.Claims;
using System.Security.Principal;
using HouseHoldApp.MVC.Infrastructure;
using Microsoft.AspNet.Identity;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Infrastructure
{
    [TestFixture]
    public class CurrentUserTests
    {
        [TestCase]
        public void Constructor_SetsProperties()
        {
            IIdentity identity = new ClaimsIdentity("IdentityUserName");
            CurrentUser currentUser = new CurrentUser(identity);
            Assert.True(currentUser.IsAuthenticated == identity.IsAuthenticated
                         && currentUser.UserId == identity.GetUserId()
                         && currentUser.UserName == identity.GetUserName());
        }

    }
}
