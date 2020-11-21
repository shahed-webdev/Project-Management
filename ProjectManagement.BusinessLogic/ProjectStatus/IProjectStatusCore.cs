using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public interface IProjectStatusCore
    {
        DbResponse Add(ProjectStatusAddModel model);
        DbResponse Edit(ProjectStatusViewModel model);
        DbResponse<List<ProjectStatusViewModel>> List();
        DbResponse<List<DDL>> Ddl();
    }
}