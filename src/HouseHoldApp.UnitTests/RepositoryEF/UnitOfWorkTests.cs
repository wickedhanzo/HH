using HouseHoldApp.Domain.Repository;
using HouseHoldApp.Domain.UnitOfWork;
using HouseHoldApp.RepositoryEF;
using HouseHoldApp.RepositoryEF.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace HouseHoldApp.UnitTests.RepositoryEF
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        public class MockContext : HhContext
        {
            public bool DisposeCalled { get; set; }
            public new void Dispose()
            {
                DisposeCalled = true;
            }
        }
        [TestCase]
        public void UnitOfWork_SaveChanges_CallsSaveChangesOnContext()
        {
            //Arrange
            Mock<HhContext> context = new Mock<HhContext>();
            IUnitOfWork uow = new UnitOfWorkEF(context.Object);
            //Act
            uow.SaveChanges();
            //Assert
            context.Verify(u => u.SaveChanges(), Times.Once);
        }

        [TestCase]
        public void UnitOfWork_Dispose_CallsDisposeOnContext()
        {
            //Arrange
            MockContext context = new MockContext();
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            IUnitOfWork uow = new UnitOfWorkEF(context);
            //Act
            uow.Dispose();
            //Assert
            context.DisposeCalled = true;
        }
    }
}
