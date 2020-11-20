using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IProjectSectorRepository
    {
        void Add(ProjectSectorAddModel model);
        bool IsExist(string sector);
        List<ProjectSectorViewModel> List();
    }


}