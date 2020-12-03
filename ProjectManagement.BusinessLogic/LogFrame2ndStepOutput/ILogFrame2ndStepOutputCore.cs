using ProjectManagement.ViewModel;

namespace ProjectManagement.BusinessLogic
{
    public interface ILogFrame2ndStepOutputCore
    {
        DbResponse AddorUpdate(LogFrame2ndStepModel model);
        DbResponse<LogFrame2ndStepModel> Get(int projectId);
    }
}