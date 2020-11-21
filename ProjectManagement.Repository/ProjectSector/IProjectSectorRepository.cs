using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IProjectSectorRepository
    {
        void Add(ProjectSectorAddModel model);
        void Edit(ProjectSectorViewModel model);
        bool IsExist(string sector);
        bool IsExist(string sector, int updateId);
        List<ProjectSectorViewModel> List();
    }


}