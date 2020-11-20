using System;

namespace ProjectManagement.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IDonorRepository Donor { get; }
        IRegistrationRepository Registration { get; }
        IProjectSectorRepository ProjectSector { get; }
        IProjectStatusRepository ProjectStatus { get; }
        IProjectBeneficiaryTypeRepository ProjectBeneficiaryType { get; }
        int SaveChanges();
    }
}