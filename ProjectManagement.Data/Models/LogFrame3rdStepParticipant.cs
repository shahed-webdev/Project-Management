namespace ProjectManagement.Data
{
    public class LogFrame3rdStepParticipant
    {
        public int LogFrame3rdStepParticipantId { get; set; }
        public int ProjectBeneficiaryTypeId { get; set; }
        public int LogFrame3rdStepActivityId { get; set; }
        public int Count { get; set; }
        public ProjectBeneficiaryType ProjectBeneficiaryType { get; set; }
        public LogFrame3rdStepActivity LogFrame3rdStepActivity { get; set; }
    }
}