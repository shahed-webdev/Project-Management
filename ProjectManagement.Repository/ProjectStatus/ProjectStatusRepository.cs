using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class ProjectStatusRepository : Repository, IProjectStatusRepository
    {
        public ProjectStatusRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void Add(ProjectStatusAddModel model)
        {
            var status = _mapper.Map<ProjectStatus>(model);
            Db.ProjectStatus.Add(status);
        }

        public bool IsExist(string status)
        {
            return Db.ProjectStatus.Any(c => c.Status == status);
        }

        public List<ProjectStatusViewModel> List()
        {
            return Db.ProjectStatus
                .ProjectTo<ProjectStatusViewModel>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.Status)
                .ToList();
        }

        public List<DDL> Ddl()
        {
            return Db.ProjectStatus
                .OrderBy(p => p.Status)
                .Select(s => new DDL
                {
                    value = s.ProjectStatusId.ToString(),
                    label = s.Status
                })
                .ToList();
        }
    }
}