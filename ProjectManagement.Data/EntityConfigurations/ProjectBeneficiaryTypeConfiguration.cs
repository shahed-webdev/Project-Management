using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class ProjectBeneficiaryTypeConfiguration : IEntityTypeConfiguration<ProjectBeneficiaryType>
    {
        public void Configure(EntityTypeBuilder<ProjectBeneficiaryType> builder)
        {
            builder.Property(b => b.BeneficiaryType)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}