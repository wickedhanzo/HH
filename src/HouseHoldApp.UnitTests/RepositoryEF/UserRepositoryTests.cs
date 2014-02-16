using System;
using System.Data.Entity;
using HouseHoldApp.Domain;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.Infrastructure.UnitOfWork;
using HouseHoldApp.RepositoryEF;
using HouseHoldApp.RepositoryEF.Repositories;
using HouseHoldApp.RepositoryEF.UnitOfWork;
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

    }
}
