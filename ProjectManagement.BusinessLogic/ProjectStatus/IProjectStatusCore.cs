using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public interface IProjectStatusCore
    {
        DbResponse Add(ProjectStatusAddModel model);
        DbResponse Delete(int projectStatusId);
        DbResponse Edit(ProjectStatusViewModel model);
        DbResponse<List<ProjectStatusViewModel>> List();
        DbResponse<List<DDL>> Ddl();
    }
}