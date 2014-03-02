using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.TestBase.ObjectMothers;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.Domain.DomainServices
{
    public class UserServiceTests
    {
        Mock<IUserStore<User>> _userStore;
        Mock<UserManager<User>> _userManager;
        IUserService _userService;
        [TestCase]
        public void CreateAsync_CallsCreateAsyncOnUserManager()
        {
            //Arrange
            SetupUserService();
            User user = UserObjectMother.GetUserWithRandomId();
            const string password = "Password";
            //Act
            _userService.CreateAsync(user, password);
            //Assert
            _userManager.Verify(u => u.CreateAsync(user, password), Times.Once);
        }
        [TestCase]
        public void CreateIdentityAsync_CallsCreateIdentityAsyncOnUserManager()
        {
            //Arrange
            SetupUserService();
            const string applicationCookie = "applicationCookie";
            User user = UserObjectMother.GetUserWithRandomId();
            //Act
            _userService.CreateIdentityAsync(user, applicationCookie);
            //Assert
            _userManager.Verify(u => u.CreateIdentityAsync(user, applicationCookie), Times.Once);
        }

        [TestCase]
        public void FindAsync_CallsFindAsyncOnUserManager()
        {
            //Arrange
            SetupUserService();
            const string userName = "UserName";
            const string password = "Password";
            //Act
            _userService.FindAsync(userName, password);
            //Assert
            _userManager.Verify(u => u.FindAsync(userName, password), Times.Once);
        }

        private void SetupUserService()
        {
            _userStore = new Mock<IUserStore<User>>();
            _userManager = new Mock<UserManager<User>>(_userStore.Object);
            _userService = new UserService(_userManager.Object);
        }

    }
}
