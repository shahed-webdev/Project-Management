using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class ProjectSector
    {
        public ProjectSector()
        {
            Projects = new HashSet<Project>();
        }
        public int ProjectSectorId { get; set; }
        public string Sector { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}