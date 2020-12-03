using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class LogFrame3rdStepActivityConfiguration : IEntityTypeConfiguration<LogFrame3rdStepActivity>
    {
        public void Configure(EntityTypeBuilder<LogFrame3rdStepActivity> builder)
        {
            builder.HasOne(l => l.Project)
                .WithOne(p => p.LogFrame3rdStepActivity)
                .HasForeignKey<LogFrame3rdStepActivity>(l => l.ProjectId)
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

            builder.Property(l => l.Frequency3)
                .HasMaxLength(50);

            builder.Property(l => l.Location)
                .HasMaxLength(50);

            builder.Property(l => l.MeasuringUnit)
                .HasMaxLength(50);


            builder.Property(l => l.Participants)
                .HasMaxLength(50);

            builder.Property(l => l.PrimarySource)
                .HasMaxLength(50);

            builder.Property(l => l.CurrencyMeasuringUnit)
                .HasMaxLength(50);

            builder.Property(l => l.SummaryOrRemarks)
                .HasMaxLength(128);

            builder.Property(l => l.ReasonOfDeviation)
                .HasMaxLength(128);


            builder.Property(p => p.Budget)
                .HasColumnType("decimal(18, 2)");

            builder.Property(p => p.Expenditure)
                .HasColumnType("decimal(18, 2)");
        }
    }
}