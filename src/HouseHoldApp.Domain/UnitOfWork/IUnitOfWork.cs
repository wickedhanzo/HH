using System;
using HouseHoldApp.Domain.Repository;

namespace HouseHoldApp.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
