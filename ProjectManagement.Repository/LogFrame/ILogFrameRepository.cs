using ProjectManagement.ViewModel;

namespace ProjectManagement.Repository
{
    public interface ILogFrameRepository
    {
        void AddorUpdate(LogFrameModel model);
        bool IsExist(int projectId);
        LogFrameModel Get(int projectId);

    }
}