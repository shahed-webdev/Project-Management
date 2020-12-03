using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Donor> Donor { get; set; }
        public virtual DbSet<LogFrame> LogFrame { get; set; }
        public virtual DbSet<LogFrame1stStepIndicator> LogFrame1stStepIndicator { get; set; }
        public virtual DbSet<LogFrame2ndStepOutput> LogFrame2ndStepOutput { get; set; }
        public virtual DbSet<LogFrame3rdStepActivity> LogFrame3rdStepActivity { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectBeneficiary> ProjectBeneficiary { get; set; }
        public virtual DbSet<ProjectBeneficiaryType> ProjectBeneficiaryType { get; set; }
        public virtual DbSet<ProjectDonor> ProjectDonor { get; set; }
        public virtual DbSet<ProjectReports> ProjectReports { get; set; }
        public virtual DbSet<ProjectSector> ProjectSector { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatus { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<ReportType> ReportType { get; set; }
        public virtual DbSet<State> State { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new DonorConfiguration());
            builder.ApplyConfiguration(new LogFrameConfiguration());
            builder.ApplyConfiguration(new LogFrame1stStepIndicatorConfiguration());
            builder.ApplyConfiguration(new LogFrame2ndStepOutputConfiguration());
            builder.ApplyConfiguration(new LogFrame3rdStepActivityConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new ProjectBeneficiaryConfiguration());
            builder.ApplyConfiguration(new ProjectBeneficiaryTypeConfiguration());
            builder.ApplyConfiguration(new ProjectDonorConfiguration());
            builder.ApplyConfiguration(new ProjectReportsConfiguration());
            builder.ApplyConfiguration(new ProjectSectorConfiguration());
            builder.ApplyConfiguration(new ProjectStatusConfiguration());
            builder.ApplyConfiguration(new RegistrationConfiguration());
            builder.ApplyConfiguration(new ReportTypeConfiguration());
            builder.ApplyConfiguration(new StateConfiguration());

            base.OnModelCreating(builder);
            builder.SeedAdminData();
        }
    }
}