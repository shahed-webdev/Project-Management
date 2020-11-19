using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class ProjectSectorConfiguration : IEntityTypeConfiguration<ProjectSector>
    {
        public void Configure(EntityTypeBuilder<ProjectSector> builder)
        {
            builder.Property(s => s.Sector)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}