using System.Data.Entity;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.Domain.UnitOfWork;

namespace HouseHoldApp.RepositoryEF.UnitOfWork
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        public UnitOfWorkEF(HhContext context)
        {
            DbContext = context;
        }

        public HhContext DbContext { get; set; }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
