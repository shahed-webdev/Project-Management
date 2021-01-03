using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IProjectStatusRepository
    {
        void Add(ProjectStatusAddModel model);
        void Delete(int projectStatusId);
        bool IsRelatedDataExist(int projectStatusId);
        void Edit(ProjectStatusViewModel model);
        bool IsNull(int projectStatusId);
        bool IsExist(string status);
        bool IsExist(string status, int updateId);
        List<ProjectStatusViewModel> List();
        List<DDL> Ddl();
    }
}