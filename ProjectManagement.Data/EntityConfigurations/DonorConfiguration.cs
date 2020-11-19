using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class DonorConfiguration : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(d => d.Phone)
                .HasMaxLength(50);

            builder.Property(d => d.Email)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}