using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class ProjectDonorConfiguration : IEntityTypeConfiguration<ProjectDonor>
    {
        public void Configure(EntityTypeBuilder<ProjectDonor> builder)
        {
            builder.HasOne(d => d.Project)
                .WithMany(p => p.ProjectDonors)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Donor)
                .WithMany(p => p.ProjectDonors)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}