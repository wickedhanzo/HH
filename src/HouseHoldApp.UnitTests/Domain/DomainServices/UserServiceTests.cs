using HouseHoldApp.Domain.DomainServices;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.TestBase.ObjectMothers;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.Domain.DomainServices
{
    [TestFixture]
    public class UserServiceTests
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

        [TestCase]
        public void VerifyValidUser_ReturnsFalse_WhenUserDoesNotExists()
        {
            //Arrange
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            User user = UserObjectMother.GetUserWithRandomId();
            user.EmailAddress = "test@gmail.com";
            userRepository.Setup(u => u.FindByEmailAddress(user.EmailAddress)).Returns(value: null);
            IUserService userService = new UserService(userRepository.Object);
            //Act
            bool isValidUser = userService.IsValidUser(user, null);
            //Assert
            Assert.False(isValidUser);
        }

        [TestCase]
        public void VerifyValidUser_ReturnsTrue_WhenUserExistsWithValidPassword()
        {
            //Arrange
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            User userDb = UserObjectMother.GetUserWithRandomId();
            userDb.EmailAddress = "test@gmail.com";
            userDb.Password = "testpwHashed";
            User userInput = new User {EmailAddress = "test@gmail.com", Password = "testpw"};
            Mock<IPasswordHasher> passwordHasher = new Mock<IPasswordHasher>();
            passwordHasher.Setup(p => p.VerifyHashedPassword(userDb.Password, userInput.Password)).Returns(PasswordVerificationResult.Success);
            userRepository.Setup(u => u.FindByEmailAddress(userDb.EmailAddress)).Returns(userDb);
            IUserService userService = new UserService(userRepository.Object);         
            //Act
            bool isValidUser = userService.IsValidUser(userInput, passwordHasher.Object);
            //Assert
            Assert.True(isValidUser);
        }

        [TestCase]
        public void VerifyValidUser_ReturnsFalse_WhenUserExistsWithInValidPassword()
        {
            //Arrange
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            User userDb = UserObjectMother.GetUserWithRandomId();
            userDb.EmailAddress = "test@gmail.com";
            userDb.Password = "testpwHashed";
            User userInput = new User { EmailAddress = "test@gmail.com", Password = "testpw" };
            Mock<IPasswordHasher> passwordHasher = new Mock<IPasswordHasher>();
            passwordHasher.Setup(p => p.VerifyHashedPassword(userDb.Password, userInput.Password)).Returns(PasswordVerificationResult.Failed);
            userRepository.Setup(u => u.FindByEmailAddress(userDb.EmailAddress)).Returns(userDb);
            IUserService userService = new UserService(userRepository.Object);
            //Act
            bool isValidUser = userService.IsValidUser(userInput, passwordHasher.Object);
            //Assert
            Assert.False(isValidUser);
        }

        [TestCase]
        public void FindByEmailAddress_ReturnsUserReturnedByRepository()
        {
            //Arrange
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            User user = UserObjectMother.GetUserWithRandomId();
            userRepository.Setup(ur => ur.FindByEmailAddress("test1@email.com")).Returns(user);
            IUserService userService = new UserService(userRepository.Object);
            //Act
            User userFound = userService.FindByEmailAddress("test1@email.com");
            //Arrange
            Assert.AreEqual(user, userFound);

        }
    }
}
