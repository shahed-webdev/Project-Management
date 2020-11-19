using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.Property(s => s.StateName)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasOne(s => s.Country)
                .WithMany(c => c.States)
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}