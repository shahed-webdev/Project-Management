using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class ProjectBeneficiaryConfiguration : IEntityTypeConfiguration<ProjectBeneficiary>
    {
        public void Configure(EntityTypeBuilder<ProjectBeneficiary> builder)
        {
            builder.HasOne(b => b.Project)
                .WithMany(p => p.ProjectBeneficiaries)
                .HasForeignKey(b => b.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(b => b.ProjectBeneficiaryType)
                .WithMany(p => p.ProjectBeneficiaries)
                .HasForeignKey(b => b.ProjectBeneficiaryTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}