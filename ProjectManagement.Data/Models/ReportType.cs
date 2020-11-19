using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class ReportType
    {
        public ReportType()
        {
            ProjectReports = new HashSet<ProjectReports>();
        }
        public int ReportTypeId { get; set; }
        public string ReportName { get; set; }
        public ICollection<ProjectReports> ProjectReports { get; set; }
    }
}