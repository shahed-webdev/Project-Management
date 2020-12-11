namespace ProjectManagement.Data
{
    public class LogFrame1stStepParticipant
    {
        public int LogFrame1stStepParticipantId { get; set; }
        public int ProjectBeneficiaryTypeId { get; set; }
        public int LogFrame1stStepIndicatorId { get; set; }
        public int Count { get; set; }
        public ProjectBeneficiaryType ProjectBeneficiaryType { get; set; }
        public LogFrame1stStepIndicator LogFrame1stStepIndicator { get; set; }
    }
}