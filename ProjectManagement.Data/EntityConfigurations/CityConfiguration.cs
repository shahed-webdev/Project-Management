using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.CityName)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasOne(c => c.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(c => c.StateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}