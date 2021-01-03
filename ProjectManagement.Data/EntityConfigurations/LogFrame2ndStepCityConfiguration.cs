using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class LogFrame2ndStepCityConfiguration : IEntityTypeConfiguration<LogFrame2ndStepCity>
    {
        public void Configure(EntityTypeBuilder<LogFrame2ndStepCity> builder)
        {
            builder.HasOne(d => d.LogFrame2ndStepOutput)
                .WithMany(p => p.LogFrame2ndStepCities)
                .HasForeignKey(d => d.LogFrame2ndStepOutputId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.City)
                .WithMany(p => p.LogFrame2ndStepCities)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}