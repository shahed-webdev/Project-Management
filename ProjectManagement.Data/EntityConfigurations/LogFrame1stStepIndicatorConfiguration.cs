using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class LogFrame1stStepIndicatorConfiguration : IEntityTypeConfiguration<LogFrame1stStepIndicator>
    {
        public void Configure(EntityTypeBuilder<LogFrame1stStepIndicator> builder)
        {
            builder.HasOne(l => l.Project)
                .WithOne(p => p.LogFrame1stStepIndicator)
                .HasForeignKey<LogFrame1stStepIndicator>(l => l.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(l => l.AchieveValue)
                .HasColumnType("decimal(18, 2)");

            builder.Property(l => l.BaselineDate)
                .HasColumnType("date");

            builder.Property(l => l.BaselineValue)
                .HasColumnType("decimal(18, 2)");

            builder.Property(l => l.TargetValue)
                .HasColumnType("decimal(18, 2)");

            builder.Property(l => l.Date1)
                .HasColumnType("date");

            builder.Property(l => l.Date2)
                .HasColumnType("date");

            builder.Property(l => l.Frequency1)
                .HasMaxLength(50);

            builder.Property(l => l.Frequency2)
                .HasMaxLength(50);

            builder.Property(l => l.Location)
                .HasMaxLength(50);

            builder.Property(l => l.MeasuringUnit)
                .HasMaxLength(50);

            builder.Property(l => l.Outcome)
                .HasMaxLength(255);

            builder.Property(l => l.OutcomeBaseIndicator)
                .HasMaxLength(255);

            builder.Property(l => l.ProjectGoal)
                .HasMaxLength(255);

            builder.Property(l => l.ResultBaseIndicator)
                .HasMaxLength(255);
            builder.Property(l => l.PrimarySource)
                .HasMaxLength(50);

            builder.HasOne(p => p.City)
                .WithMany(c => c.LogFrame1stStepIndicators)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}