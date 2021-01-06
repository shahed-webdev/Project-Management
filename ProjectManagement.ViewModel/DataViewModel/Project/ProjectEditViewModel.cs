using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace ProjectManagement.ViewModel
{
    public class ProjectEditViewModel
    {
        public ProjectEditViewModel()
        {
            ProjectBeneficiaries = new HashSet<ProjectBeneficiaryAddModel>();
            ProjectReports = new HashSet<ProjectReportsAddModel>();
            ProjectDonors = new HashSet<DonorViewModel>();
            Locations = new HashSet<CityWithStateCountryViewModel>();
        }
        public int ProjectId { get; set; }
        public int ProjectSectorId { get; set; }
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
        public string FilePhotoUrl { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public int[] ProjectDonorIds { get; set; }
        public ICollection<DonorViewModel> ProjectDonors { get; set; }
        public ICollection<ProjectReportsAddModel> ProjectReports { get; set; }
        public ICollection<ProjectBeneficiaryAddModel> ProjectBeneficiaries { get; set; }
        public ICollection<CityWithStateCountryViewModel> Locations { get; set; }
    }
}