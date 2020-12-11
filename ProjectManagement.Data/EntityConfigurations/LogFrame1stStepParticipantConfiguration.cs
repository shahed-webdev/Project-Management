using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class LogFrame1stStepParticipantConfiguration : IEntityTypeConfiguration<LogFrame1stStepParticipant>
    {
        public void Configure(EntityTypeBuilder<LogFrame1stStepParticipant> builder)
        {
            builder.HasOne(b => b.LogFrame1stStepIndicator)
                .WithMany(p => p.LogFrame1stStepParticipants)
                .HasForeignKey(b => b.LogFrame1stStepIndicatorId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(b => b.ProjectBeneficiaryType)
                .WithMany(p => p.LogFrame1stStepParticipants)
                .HasForeignKey(b => b.ProjectBeneficiaryTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}