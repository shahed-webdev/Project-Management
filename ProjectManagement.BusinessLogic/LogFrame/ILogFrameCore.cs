using ProjectManagement.ViewModel;

namespace ProjectManagement.BusinessLogic
{
    public interface ILogFrameCore
    {
        DbResponse AddorUpdate(LogFrameModel model);
        DbResponse<LogFrameModel> Get(int projectId);
    }
}