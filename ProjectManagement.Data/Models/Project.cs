using System;
using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class Project
    {
        public Project()
        {
            ProjectDonors = new HashSet<ProjectDonor>();
            ProjectReports = new HashSet<ProjectReports>();
            ProjectBeneficiaries = new HashSet<ProjectBeneficiary>();
        }
        public int ProjectId { get; set; }
        public int ProjectSectorId { get; set; }
        public int? ProjectStatusId { get; set; }
        public int? CityId { get; set; }
        public string Title { get; set; }
        public string ProjectName { get; set; }
        public string ReportName { get; set; }
        public string Description { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal TotalExpenditure { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public ProjectSector ProjectSector { get; set; }
        public City City { get; set; }
        public ICollection<ProjectDonor> ProjectDonors { get; set; }
        public ICollection<ProjectReports> ProjectReports { get; set; }
        public ICollection<ProjectBeneficiary> ProjectBeneficiaries { get; set; }

    }
}