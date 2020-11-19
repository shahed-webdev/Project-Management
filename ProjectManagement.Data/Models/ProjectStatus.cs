using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class ProjectStatus
    {
        public ProjectStatus()
        {
            Projects = new HashSet<Project>();
        }
        public int ProjectStatusId { get; set; }
        public string Status { get; set; }
        public ICollection<Project> Projects { get; set; }
    }

}