using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class ProjectSectorRepository : Repository, IProjectSectorRepository
    {
        public ProjectSectorRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void Add(ProjectSectorAddModel model)
        {
            var sector = _mapper.Map<ProjectSector>(model);
            Db.ProjectSector.Add(sector);
        }

        public bool IsExist(string sector)
        {
            return Db.ProjectSector.Any(c => c.Sector == sector);
        }

        public List<ProjectSectorViewModel> List()
        {
            return Db.ProjectSector
                .ProjectTo<ProjectSectorViewModel>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.Sector)
                .ToList();
        }
    }
}