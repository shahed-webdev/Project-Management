using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class ReportTypeConfiguration : IEntityTypeConfiguration<ReportType>
    {
        public void Configure(EntityTypeBuilder<ReportType> builder)
        {
            builder.Property(r => r.ReportName)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}