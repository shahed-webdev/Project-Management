using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IProjectRepository
    {
        void Add(ProjectAddModel model);
        void Edit(ProjectEditViewModel model);
        ProjectEditViewModel Get(int projectId);
        void Delete(int projectId);
        bool IsRelatedDataExist(int projectId);
        bool IsExist(string title);
        bool IsExist(string title, int updateId);
        bool IsNull(int projectId);
        List<ProjectListViewModel> List(int sectorId);
        List<DDL> Ddl(int sectorId);
        void AddExpediter(ProjectExpediterAddModel model);

        List<ProjectReportsAddModel> Reports(int projectId);
    }
}