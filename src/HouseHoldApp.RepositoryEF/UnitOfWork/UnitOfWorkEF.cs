using System.Data.Entity;
using HouseHoldApp.Domain.Repository;
using HouseHoldApp.Domain.UnitOfWork;

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

        public UnitOfWorkEF(HhContext context, IUserRepository userRepository, IHouseHoldRepository houseHoldRepository, IHouseHoldMemberRepository houseHoldMemberRepository)
        {
            _context = context;
            UserRepository = userRepository;
            HouseHoldRepository = houseHoldRepository;
            HouseHoldMemberRepository = houseHoldMemberRepository;
        }

        public IUserRepository UserRepository { get; private set; }
        public IHouseHoldRepository HouseHoldRepository { get; private set; }
        public IHouseHoldMemberRepository HouseHoldMemberRepository { get; private set; }
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
