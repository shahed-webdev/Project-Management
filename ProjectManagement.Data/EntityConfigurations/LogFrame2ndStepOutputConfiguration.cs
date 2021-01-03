using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class LogFrame2ndStepOutputConfiguration : IEntityTypeConfiguration<LogFrame2ndStepOutput>
    {
        public void Configure(EntityTypeBuilder<LogFrame2ndStepOutput> builder)
        {
            builder.HasOne(l => l.Project)
                .WithOne(p => p.LogFrame2ndStepOutput)
                .HasForeignKey<LogFrame2ndStepOutput>(l => l.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(l => l.Output)
                .HasMaxLength(255);

            builder.Property(l => l.OutputBaseIndicator)
                .HasMaxLength(255);

            builder.Property(l => l.BaselineValue)
                .HasColumnType("decimal(18, 2)");

            builder.Property(l => l.TargetValue)
                .HasColumnType("decimal(18, 2)");

            builder.Property(l => l.AchieveValue)
                .HasColumnType("decimal(18, 2)");

            builder.Property(l => l.BaselineDate)
                .HasColumnType("date");


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

            builder.Property(l => l.PrimarySource)
                .HasMaxLength(50);
        }
    }
}