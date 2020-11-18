using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new RegistrationConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());

            base.OnModelCreating(builder);
            builder.SeedAdminData();
        }
    }
}