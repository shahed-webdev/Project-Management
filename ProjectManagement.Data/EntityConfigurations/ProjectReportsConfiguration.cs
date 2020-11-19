using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class ProjectReportsConfiguration : IEntityTypeConfiguration<ProjectReports>
    {
        public void Configure(EntityTypeBuilder<ProjectReports> builder)
        {
            builder.Property(r => r.FileName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(r => r.FileUrl)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(r => r.Project)
                .WithMany(p => p.ProjectReports)
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.ReportType)
                .WithMany(t => t.ProjectReports)
                .HasForeignKey(r => r.ReportTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}