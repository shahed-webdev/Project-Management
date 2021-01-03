using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class LogFrame1stStepCityConfiguration : IEntityTypeConfiguration<LogFrame1stStepCity>
    {
        public void Configure(EntityTypeBuilder<LogFrame1stStepCity> builder)
        {
            builder.HasOne(d => d.LogFrame1stStepIndicator)
                .WithMany(p => p.LogFrame1stStepCities)
                .HasForeignKey(d => d.LogFrame1stStepIndicatorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.City)
                .WithMany(p => p.LogFrame1stStepCities)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}