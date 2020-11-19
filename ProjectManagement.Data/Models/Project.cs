using System;

namespace ProjectManagement.Data
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectStatusId { get; set; }
        public virtual ProjectStatus ProjectStatus { get; set; }

    }
}