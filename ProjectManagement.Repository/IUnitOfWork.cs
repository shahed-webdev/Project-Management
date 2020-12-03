using System;

namespace ProjectManagement.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository City { get; }
        ICountryRepository Country { get; }
        IDonorRepository Donor { get; }
        ILogFrameRepository LogFrame { get; }
        ILogFrame1stStepIndicatorRepository LogFrame1stStepIndicator { get; }
        ILogFrame2ndStepOutputRepository LogFrame2ndStepOutput { get; }
        ILogFrame3rdStepActivityRepository LogFrame3rdStepActivity { get; }
        IRegistrationRepository Registration { get; }
        IProjectRepository Project { get; }
        IProjectSectorRepository ProjectSector { get; }
        IProjectStatusRepository ProjectStatus { get; }
        IProjectBeneficiaryTypeRepository ProjectBeneficiaryType { get; }
        IReportTypeRepository ReportType { get; }
        IStateRepository State { get; }
        int SaveChanges();
    }
}