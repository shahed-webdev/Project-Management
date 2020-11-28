using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class LogFrameConfiguration : IEntityTypeConfiguration<LogFrame>
    {
        public void Configure(EntityTypeBuilder<LogFrame> builder)
        {
            builder.Property(l => l.Activity).HasMaxLength(255);

            builder.Property(l => l.Outcome).HasMaxLength(255);

            builder.Property(l => l.OutcomeBaseIndicator).HasMaxLength(255);

            builder.Property(l => l.Output).HasMaxLength(255);

            builder.Property(l => l.OutputBaseIndicator).HasMaxLength(255);

            builder.Property(l => l.ProjectGoal).HasMaxLength(255);

            builder.Property(l => l.ResultBaseIndicator).HasMaxLength(255);

            builder.HasOne(l => l.Project)
                .WithOne(p => p.LogFrame)
                .HasForeignKey<LogFrame>(l => l.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}