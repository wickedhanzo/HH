using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.Entities;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.RepositoryEF.Repositories;
using HouseHoldApp.TestBase.ObjectMothers;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.RepositoryEF
{
    [TestFixture]
    public class UserRepositoryTests
    {
        [TestCase]
        public void UserRepository_Add_CreatesUser()
        {
            //Arrange
            Mock<DbSet<User>> dbSet = new Mock<DbSet<User>>();
            IUserRepository userRepository = new UserRepositoryEF(dbSet.Object);
            User user = UserObjectMother.GetUserWithRandomId();
            //Act
            userRepository.Add(user);
            //Assert
            dbSet.Verify(d => d.Add(user),Times.Once);
        }

        [TestCase]
        public void FindByEmailAddress_ReturnsCorrectUser_EmailAddressExists()
        {
            //Arrange
            User user = UserObjectMother.GetUserWithRandomId();
            user.EmailAddress = "test@gmail.com";
            IQueryable<User> users = (new List<User> { user }).AsQueryable();
            IUserRepository userRepository = CreateUserRepositoryWithSingleUser(users);
            //Act
            User userFound = userRepository.FindByEmailAddress(user.EmailAddress);
            //Assert
            Assert.True(userFound.Id == user.Id);
        }

        [TestCase]
        public void FindByEmailAddress_ReturnsCorrectUser_EmailAddressExistsAndHasOtherCasing()
        {
            //Arrange
            User user = UserObjectMother.GetUserWithRandomId();
            user.EmailAddress = "test@gmail.com";

            IQueryable<User> users = (new List<User> { user }).AsQueryable();
            IUserRepository userRepository = CreateUserRepositoryWithSingleUser(users);
            //Act
            User userFound = userRepository.FindByEmailAddress("Test@gmail.COM");
            //Assert
            Assert.True(userFound.Id == user.Id);
        }

        private IUserRepository CreateUserRepositoryWithSingleUser(IQueryable<User> users )
        {
            Mock<IDbSet<User>> dbSet = MockUtil.CreateMockSet(users);
            IUserRepository userRepository = new UserRepositoryEF(dbSet.Object);
            return userRepository;
        }
    }
}
