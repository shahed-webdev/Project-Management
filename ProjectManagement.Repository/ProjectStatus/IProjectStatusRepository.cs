using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IProjectStatusRepository
    {
        void Add(ProjectStatusAddModel model);
        void Edit(ProjectStatusViewModel model);
        bool IsExist(string status);
        bool IsExist(string status, int updateId);
        List<ProjectStatusViewModel> List();
        List<DDL> Ddl();
    }
}