using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public interface IProjectSectorCore
    {
        DbResponse Add(ProjectSectorAddModel model);
        DbResponse<List<ProjectSectorViewModel>> List();
    }
}