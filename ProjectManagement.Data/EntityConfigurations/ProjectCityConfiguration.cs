using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class ProjectCityConfiguration : IEntityTypeConfiguration<ProjectCity>
    {
        public void Configure(EntityTypeBuilder<ProjectCity> builder)
        {
            builder.HasOne(d => d.Project)
                .WithMany(p => p.ProjectCities)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.City)
                .WithMany(p => p.ProjectCities)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}