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

        public void Edit(ProjectEditViewModel model)
        {
            throw new System.NotImplementedException();
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