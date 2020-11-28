using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

            City = new CityRepository(_db, _mapper);
            Country = new CountryRepository(_db, _mapper);
            Donor = new DonorRepository(_db, _mapper);
            LogFrame = new LogFrameRepository(_db, _mapper);
            LogFrame1stStepIndicator = new LogFrame1stStepIndicatorRepository(_db, _mapper);
            Project = new ProjectRepository(_db, _mapper);
            ProjectBeneficiaryType = new ProjectBeneficiaryTypeRepository(_db, _mapper);
            ProjectSector = new ProjectSectorRepository(_db, _mapper);
            ProjectStatus = new ProjectStatusRepository(_db, _mapper);
            Registration = new RegistrationRepository(_db, _mapper);
            ReportType = new ReportTypeRepository(_db, _mapper);
            State = new StateRepository(_db, _mapper);
        }

        public ICityRepository City { get; }
        public ICountryRepository Country { get; }
        public IDonorRepository Donor { get; }
        public ILogFrameRepository LogFrame { get; }
        public ILogFrame1stStepIndicatorRepository LogFrame1stStepIndicator { get; }
        public IProjectRepository Project { get; }
        public IProjectSectorRepository ProjectSector { get; }
        public IProjectStatusRepository ProjectStatus { get; }
        public IProjectBeneficiaryTypeRepository ProjectBeneficiaryType { get; }
        public IReportTypeRepository ReportType { get; }
        public IRegistrationRepository Registration { get; }
        public IStateRepository State { get; }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}