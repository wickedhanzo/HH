using System;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        void SaveChanges();
    }
}
