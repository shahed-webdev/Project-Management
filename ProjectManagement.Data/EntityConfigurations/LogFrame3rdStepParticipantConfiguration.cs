using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class LogFrame3rdStepParticipantConfiguration : IEntityTypeConfiguration<LogFrame3rdStepParticipant>
    {
        public void Configure(EntityTypeBuilder<LogFrame3rdStepParticipant> builder)
        {
            builder.HasOne(b => b.LogFrame3rdStepActivity)
                .WithMany(p => p.LogFrame3rdStepParticipants)
                .HasForeignKey(b => b.LogFrame3rdStepActivityId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(b => b.ProjectBeneficiaryType)
                .WithMany(p => p.LogFrame3rdStepParticipants)
                .HasForeignKey(b => b.ProjectBeneficiaryTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}