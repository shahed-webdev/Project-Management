using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    }
}