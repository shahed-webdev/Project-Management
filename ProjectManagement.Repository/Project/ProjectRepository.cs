using AutoMapper;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public class ProjectRepository : Repository, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public void Add(ProjectAddModel model)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(ProjectEditViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool IsExist(string title)
        {
            throw new System.NotImplementedException();
        }

        public bool IsExist(string title, int updateId)
        {
            throw new System.NotImplementedException();
        }

        public List<ProjectListViewModel> List(int sectorId)
        {
            throw new System.NotImplementedException();
        }

        public List<DDL> Ddl(int sectorId)
        {
            throw new System.NotImplementedException();
        }
    }
}