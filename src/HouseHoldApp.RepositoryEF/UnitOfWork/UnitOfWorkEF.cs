using System.Data.Entity;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.Infrastructure.UnitOfWork;

namespace HouseHoldApp.RepositoryEF.UnitOfWork
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWorkEF(DbContext context,IUserRepository userRepository)
        {
            _context = context;
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; private set; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
