using System;

namespace ProjectManagement.ViewModel
{
    public class ProjectListViewModel
    {
        public int ProjectId { get; set; }
        public int ProjectSectorId { get; set; }
        public int? ProjectStatusId { get; set; }
        public int? CityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal TotalExpenditure { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SubmissionDate { get; set; }
    }
}