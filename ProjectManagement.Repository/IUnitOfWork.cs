using System;

namespace ProjectManagement.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRegistrationRepository Registration { get; }
        int SaveChanges();
    }
}