using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class ProjectStatusConfiguration : IEntityTypeConfiguration<ProjectStatus>
    {
        public void Configure(EntityTypeBuilder<ProjectStatus> builder)
        {
            builder.Property(s => s.Status)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}