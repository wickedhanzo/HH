using System;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        void SaveChanges();
    }
}
