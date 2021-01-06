using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class ProjectRepository : Repository, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public void Add(ProjectAddModel model)
        {
            var project = _mapper.Map<Project>(model);
            project.ReportName = model.Title;
            project.ProjectName = model.Title;
            Db.Project.Add(project);
        }

        public void Edit(ProjectEditModel model)
        {
            var project = Db.Project
                .Include(p => p.ProjectDonors)
                .Include(p => p.ProjectCities)
                .Include(p => p.ProjectBeneficiaries)
                .Include(p => p.ProjectReports)
                .FirstOrDefault(p => p.ProjectId == model.ProjectId);


            project.ProjectStatusId = model.ProjectStatusId;

            project.ProjectCities = model.CityIds != null ? model.CityIds.Select(c => new ProjectCity { CityId = c }).ToList() : new List<ProjectCity>();

            project.Title = model.Title;
            project.Description = model.Description;
            project.KeyWord = model.KeyWord;
            project.TotalBudgetBdt = model.TotalBudgetBdt;
            project.TotalBudgetUsd = model.TotalBudgetUsd;
            project.TotalExpenditure = model.TotalExpenditure;
            project.DonorType = model.DonorType;
            project.DirectIndirectType = model.DirectIndirectType;
            project.IndividualHouseholdType = model.IndividualHouseholdType;
            project.Count = model.Count;
            project.TotalCount = model.TotalCount;

            if (model.FilePhoto != null)
                project.Photo = model.Photo;

            project.StartDate = model.StartDate;
            project.EndDate = model.EndDate;
            project.SubmissionDate = model.SubmissionDate;

            project.ProjectDonors = model.ProjectDonorIds != null ? model.ProjectDonorIds.Select(d => new ProjectDonor { DonorId = d }).ToList() : new List<ProjectDonor>();

            var reports = new List<ProjectReports>();

            if (model.DeletedReports != null)
            {
                reports = project.ProjectReports
                   .Where(p => !model.DeletedReports.Select(r => r.ReportTypeId).Contains(p.ReportTypeId))?.ToList();
            }

            if (model.AddedReports != null)
            {
                var addReports = model.AddedReports.Select(r => _mapper.Map<ProjectReports>(r)).ToList();
                reports.AddRange(addReports);
            }


            if (reports.Count > 0 || model.DeletedReports.Count > 0)
                project.ProjectReports = reports;

            project.ProjectBeneficiaries = model.ProjectBeneficiaries != null ? model.ProjectBeneficiaries.Select(b => _mapper.Map<ProjectBeneficiary>(b)).ToList() : new List<ProjectBeneficiary>();


            Db.Project.Update(project);
        }

        public ProjectEditViewModel Get(int projectId)
        {
            return Db.Project
                //.Include(p => p.ProjectDonors)
                //.ThenInclude(d => d.Donor)
                //.Include(p => p.ProjectCities)
                //.ThenInclude(c => c.City)
                //.Include(p => p.ProjectBeneficiaries)
                //.Include(p => p.ProjectReports)
                .Where(p => p.ProjectId == projectId)
                .ProjectTo<ProjectEditViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        public void Delete(int projectId)
        {
            var project = Db.Project.Find(projectId);
            Db.Project.Remove(project);
        }

        public bool IsRelatedDataExist(int projectId)
        {
            if (Db.LogFrame1stStepIndicator.Any(c => c.ProjectId == projectId))
                return true;
            if (Db.LogFrame2ndStepOutput.Any(c => c.ProjectId == projectId))
                return true;
            if (Db.LogFrame3rdStepActivity.Any(c => c.ProjectId == projectId))
                return true;
            return false;
        }

        public bool IsExist(string title)
        {
            return Db.Project.Any(c => c.Title == title);
        }

        public bool IsExist(string title, int updateId)
        {
            return Db.Project.Any(c => c.Title == title && c.ProjectId != updateId);
        }

        public bool IsNull(int projectId)
        {
            return !Db.Project.Any(c => c.ProjectId == projectId);
        }

        public List<ProjectListViewModel> List(int sectorId)
        {
            return Db.Project
                .Where(p => p.ProjectSectorId == sectorId)
                .OrderBy(p => p.Title)
                .ProjectTo<ProjectListViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<DDL> Ddl(int sectorId)
        {
            return Db.Project
                .Where(p => p.ProjectSectorId == sectorId)
                .OrderBy(p => p.Title)
                .Select(s => new DDL
                {
                    value = s.ProjectId.ToString(),
                    label = s.Title
                })
                .ToList();
        }

        public void AddExpediter(ProjectExpediterAddModel model)
        {
            var project = Db.Project.Find(model.ProjectId);
            if (project == null) return;

            project.TotalExpenditure += model.Expenditure;
            Db.Project.Update(project);
        }

        public List<ProjectReportsAddModel> Reports(int projectId)
        {
            return Db.ProjectReports
                .Where(p => p.ProjectId == projectId)
                .ProjectTo<ProjectReportsAddModel>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}