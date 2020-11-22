using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class ProjectSector
    {
        public ProjectSector()
        {
            Projects = new HashSet<Project>();
            Users = new HashSet<Registration>();
        }
        public int ProjectSectorId { get; set; }
        public string Sector { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Registration> Users { get; set; }
    }
}