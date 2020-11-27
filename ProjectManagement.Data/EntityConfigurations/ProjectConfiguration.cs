using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(225);

            builder.Property(p => p.ProjectName)
                .IsRequired()
                .HasMaxLength(225);

            builder.Property(p => p.ReportName)
                .IsRequired()
                .HasMaxLength(225);

            builder.Property(p => p.TotalBudget)
                .HasColumnType("decimal(18, 2)");

            builder.Property(p => p.TotalExpenditure)
                .HasColumnType("decimal(18, 2)");

            builder.Property(p => p.Photo)
                .HasMaxLength(128);

            builder.Property(p => p.StartDate)
                .HasColumnType("date");

            builder.Property(p => p.EndDate)
                .HasColumnType("date");

            builder.Property(p => p.SubmissionDate)
                .HasColumnType("date");

            builder.HasOne(p => p.City)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ProjectSector)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ProjectSectorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ProjectStatus)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ProjectStatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}