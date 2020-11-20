using System;

namespace ProjectManagement.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRegistrationRepository Registration { get; }
        IProjectSectorRepository ProjectSector { get; }
        int SaveChanges();
    }
}