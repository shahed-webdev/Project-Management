using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IProjectRepository
    {
        void Add(ProjectAddModel model);
        void Edit(ProjectEditViewModel model);
        bool IsExist(string title);
        bool IsExist(string title, int updateId);
        List<ProjectListViewModel> List(int sectorId);
        List<DDL> Ddl(int sectorId);
    }
}