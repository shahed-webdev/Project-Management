using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class LogFrame3rdStepCityConfiguration : IEntityTypeConfiguration<LogFrame3rdStepCity>
    {
        public void Configure(EntityTypeBuilder<LogFrame3rdStepCity> builder)
        {
            builder.HasOne(d => d.LogFrame3rdStepActivity)
                .WithMany(p => p.LogFrame3rdStepCities)
                .HasForeignKey(d => d.LogFrame3rdStepActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.City)
                .WithMany(p => p.LogFrame3rdStepCities)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}