using ProjectManagement.ViewModel.Project;
using System;
using System.Collections.Generic;

namespace ProjectManagement.ViewModel
{
    public class ProjectAddModel
    {
        public ProjectAddModel()
        {
            ProjectBeneficiaries = new HashSet<ProjectBeneficiaryAddModel>();
            ProjectReports = new HashSet<ProjectReportsAddModel>();
        }
        public int ProjectSectorId { get; set; }
        public int ProjectStatusId { get; set; }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal TotalExpenditure { get; set; }
        public byte[] Photo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int[] ProjectDonors { get; set; }
        public ICollection<ProjectReportsAddModel> ProjectReports { get; set; }
        public ICollection<ProjectBeneficiaryAddModel> ProjectBeneficiaries { get; set; }
    }
}