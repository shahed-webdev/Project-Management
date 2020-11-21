using System;

namespace ProjectManagement.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository City { get; }
        ICountryRepository Country { get; }
        IDonorRepository Donor { get; }
        IRegistrationRepository Registration { get; }
        IProjectSectorRepository ProjectSector { get; }
        IProjectStatusRepository ProjectStatus { get; }
        IProjectBeneficiaryTypeRepository ProjectBeneficiaryType { get; }
        IStateRepository State { get; }
        int SaveChanges();
    }
}