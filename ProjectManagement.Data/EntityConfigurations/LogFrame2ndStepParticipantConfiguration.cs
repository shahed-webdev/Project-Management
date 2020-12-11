using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManagement.Data
{
    public class LogFrame2ndStepParticipantConfiguration : IEntityTypeConfiguration<LogFrame2ndStepParticipant>
    {
        public void Configure(EntityTypeBuilder<LogFrame2ndStepParticipant> builder)
        {
            builder.HasOne(b => b.LogFrame2ndStepOutput)
                .WithMany(p => p.LogFrame2ndStepParticipants)
                .HasForeignKey(b => b.LogFrame2ndStepOutputId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(b => b.ProjectBeneficiaryType)
                .WithMany(p => p.LogFrame2ndStepParticipants)
                .HasForeignKey(b => b.ProjectBeneficiaryTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}