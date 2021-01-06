using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public interface IProjectCore
    {
        DbResponse Add(ProjectAddModel model);
        DbResponse Delete(int projectId);
        DbResponse<ProjectEditViewModel> Get(int projectId);
        DbResponse Edit(ProjectEditModel model);
        DbResponse<List<ProjectListViewModel>> List(int sectorId);
        DbResponse<List<ProjectReportsAddModel>> Reports(int projectId);
        DbResponse<List<DDL>> Ddl(int sectorId);
        DbResponse AddExpediter(ProjectExpediterAddModel model);
    }
}