using System;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.RepositoryEF.Repositories;
using HouseHoldApp.TestBase.ObjectMothers;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.Domain.DomainServices
{
    [TestFixture]
    public class UserServiceTest
    {
        [TestCase]
        public void RegisterUser_CallsAddOnUserRepository()
        {
            //Arrange
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            IUserService userService = new UserService(userRepository.Object);
            User user = UserObjectMother.GetUserWithRandomId();
            //Act
            userService.RegisterUser(user);
            //Assert
            userRepository.Verify(m => m.Add(user), Times.Once);
        }
    }
}
