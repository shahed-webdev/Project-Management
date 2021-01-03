namespace ProjectManagement.Data
{
    public class ProjectReports
    {
        public int ProjectReportsId { get; set; }
        public int ReportTypeId { get; set; }
        public int ProjectId { get; set; }
        public string FileName { get; set; }
        public string FileTitle { get; set; }
        public string FileUrl { get; set; }
        public ReportType ReportType { get; set; }
        public Project Project { get; set; }
    }
}