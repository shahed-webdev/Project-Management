using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public interface IProjectCore
    {
        DbResponse Add(ProjectAddModel model);
        DbResponse Edit(ProjectEditViewModel model);
        DbResponse<List<ProjectListViewModel>> List(int sectorId);
        DbResponse<List<DDL>> Ddl(int sectorId);
    }
}