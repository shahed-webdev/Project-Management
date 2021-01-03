using Microsoft.AspNetCore.Http;

namespace ProjectManagement.ViewModel
{
    public class ProjectReportsAddModel
    {
        public int ReportTypeId { get; set; }
        public string ReportName { get; set; }
        public IFormFile Attachment { get; set; }
        public string FileTitle { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }

    }
}