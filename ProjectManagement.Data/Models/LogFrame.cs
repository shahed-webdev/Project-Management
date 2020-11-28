namespace ProjectManagement.Data
{
    public class LogFrame
    {

        public int LogFrameId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectGoal { get; set; }
        public string ResultBaseIndicator { get; set; }
        public string Outcome { get; set; }
        public string OutcomeBaseIndicator { get; set; }
        public string Output { get; set; }
        public string OutputBaseIndicator { get; set; }
        public string Activity { get; set; }
        public Project Project { get; set; }
    }
}