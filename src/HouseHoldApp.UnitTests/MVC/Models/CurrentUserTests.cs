using System.Security.Principal;
using System.Web.Security;
using HouseHoldApp.MVC.Models;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.MVC.Models
{
    [TestFixture]
    public class CurrentUserTests
    {
        [TestCase]
        public void Constructor_setsVariables()
        {
            Mock<IIdentity> identity = new Mock<IIdentity>();
            identity.Setup(i => i.IsAuthenticated).Returns(true);
            identity.Setup(i => i.Name).Returns("test1@email.com");
            
            CurrentUser currentUser = new CurrentUser(identity.Object);
            Assert.True(currentUser.IsAuthenticated);
            Assert.True(currentUser.EmailAddress == "test1@email.com");
        }
    }
}
