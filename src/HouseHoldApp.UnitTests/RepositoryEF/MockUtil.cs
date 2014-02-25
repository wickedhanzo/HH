using System.Data.Entity;
using System.Linq;
using Moq;

namespace HouseHoldApp.UnitTests.RepositoryEF
{
    public static class MockUtil
    {
        public static Mock<IDbSet<T>> CreateMockSet<T>(IQueryable<T> childlessParents) where T : class
        {
            var mockSet = new Mock<IDbSet<T>>();

            mockSet.Setup(m => m.Provider).Returns(childlessParents.Provider);
            mockSet.Setup(m => m.Expression).Returns(childlessParents.Expression);
            mockSet.Setup(m => m.ElementType).Returns(childlessParents.ElementType);
            mockSet.Setup(m => m.GetEnumerator()).Returns(childlessParents.GetEnumerator());
            return mockSet;
        }
    }
}
