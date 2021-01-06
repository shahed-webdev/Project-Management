using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace ProjectManagement.ViewModel
{
    public class ProjectEditModel
    {
        public ProjectEditModel()
        {
            ProjectBeneficiaries = new HashSet<ProjectBeneficiaryAddModel>();
            AddedReports = new HashSet<ProjectReportsAddModel>();
            DeletedReports = new HashSet<ProjectReportsDeleteModel>();
        }
        public int ProjectId { get; set; }
        public int? ProjectStatusId { get; set; }
        public int[] CityIds { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string KeyWord { get; set; }
        public decimal TotalBudgetBdt { get; set; }
        public decimal TotalBudgetUsd { get; set; }
        public decimal TotalExpenditure { get; set; }
        public string DonorType { get; set; }
        public string DirectIndirectType { get; set; }
        public string IndividualHouseholdType { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public string Photo { get; set; }
        public IFormFile FilePhoto { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public int[] ProjectDonorIds { get; set; }
        public ICollection<ProjectReportsAddModel> AddedReports { get; set; }
        public ICollection<ProjectReportsDeleteModel> DeletedReports { get; set; }
        public ICollection<ProjectBeneficiaryAddModel> ProjectBeneficiaries { get; set; }
    }

    public class ProjectReportsDeleteModel
    {
        public int ReportTypeId { get; set; }
        public string FileName { get; set; }
    }
}