using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class ProjectBeneficiaryType
    {
        public ProjectBeneficiaryType()
        {
            ProjectBeneficiaries = new HashSet<ProjectBeneficiary>();
            LogFrame1stStepParticipants = new HashSet<LogFrame1stStepParticipant>();
            LogFrame2ndStepParticipants = new HashSet<LogFrame2ndStepParticipant>();
            LogFrame3rdStepParticipants = new HashSet<LogFrame3rdStepParticipant>();
        }
        public int ProjectBeneficiaryTypeId { get; set; }
        public string BeneficiaryType { get; set; }
        public ICollection<ProjectBeneficiary> ProjectBeneficiaries { get; set; }
        public ICollection<LogFrame1stStepParticipant> LogFrame1stStepParticipants { get; set; }
        public ICollection<LogFrame2ndStepParticipant> LogFrame2ndStepParticipants { get; set; }
        public ICollection<LogFrame3rdStepParticipant> LogFrame3rdStepParticipants { get; set; }
    }
}