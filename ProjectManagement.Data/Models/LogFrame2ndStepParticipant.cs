namespace ProjectManagement.Data
{
    public class LogFrame2ndStepParticipant
    {
        public int LogFrame2ndStepParticipantId { get; set; }
        public int ProjectBeneficiaryTypeId { get; set; }
        public int LogFrame2ndStepOutputId { get; set; }
        public int Count { get; set; }
        public ProjectBeneficiaryType ProjectBeneficiaryType { get; set; }
        public LogFrame2ndStepOutput LogFrame2ndStepOutput { get; set; }
    }
}