using System;

namespace ProjectManagement.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}