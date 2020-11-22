using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedAdminData(this ModelBuilder builder)
        {
            var ADMIN_ID = "A0456563-F978-4135-B563-97F23EA02FDA";
            // any guid, but nothing is against to use the same one
            var ROLE_ID = "5A71C6C4-9488-4BCC-A680-445A34C6E721";
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = UserType.Admin.ToString(),
                    NormalizedName = UserType.Admin.ToString().ToUpper(),
                    ConcurrencyStamp = ROLE_ID
                },
                new IdentityRole
                {
                    Id = "F73A5277-2535-48A4-A371-300508ADDD2F",
                    Name = UserType.SubAdmin.ToString(),
                    NormalizedName = UserType.SubAdmin.ToString().ToUpper(),
                    ConcurrencyStamp = "F73A5277-2535-48A4-A371-300508ADDD2F"
                });


            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDch3arYEB9dCAudNdsYEpVX7ryywa8f3ZIJSVUmEThAI50pLh9RyEu7NjGJccpOog==",
                SecurityStamp = string.Empty,
                LockoutEnabled = true,
                ConcurrencyStamp = ADMIN_ID
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<Registration>().HasData(new Registration
            {
                RegistrationId = 1,
                UserName = "Admin",
                Type = UserType.Admin,
                Name = "Admin"
            });

            builder.Entity<Company>().HasData(new Company
            {
                CompanyId = 1,
                Name = "Company Name",
            });

            builder.Entity<ProjectSector>().HasData(
                new ProjectSector
                {
                    ProjectSectorId = 1,
                    Sector = "Access to Justice"
                },
                new ProjectSector
                {
                    ProjectSectorId = 2,
                    Sector = "Activism along the Agricultural, Fishery, Dairy and Horticulture Value Chain"
                },
                new ProjectSector
                {
                    ProjectSectorId = 3,
                    Sector = "Climate Emergency, Biodiversity and Disaster Management 1"
                },
                new ProjectSector
                {
                    ProjectSectorId = 4,
                    Sector = "Climate Emergency, Biodiversity and Disaster Management 2"
                },
                new ProjectSector
                {
                    ProjectSectorId = 5,
                    Sector = "Company as a social entrepreneurship"
                },
                new ProjectSector
                {
                    ProjectSectorId = 6,
                    Sector = "Health and Nutrition"
                },
                new ProjectSector
                {
                    ProjectSectorId = 7,
                    Sector = "Microfinance"
                },
                new ProjectSector
                {
                    ProjectSectorId = 8,
                    Sector = "Youth Development (Education, skill, moral and cultural behavior)"
                }
            );
        }
    }
}
