using ProjectManagement.ViewModel;

namespace ProjectManagement.BusinessLogic
{
    public interface ILogFrame1stStepCore
    {
        DbResponse AddorUpdate(LogFrame1stStepModel model);
        DbResponse Delete(int projectId);
        DbResponse<LogFrame1stStepModel> Get(int projectId);
    }
}