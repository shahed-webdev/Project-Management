using ProjectManagement.ViewModel;

namespace ProjectManagement.Repository
{
    public interface ILogFrame3rdStepActivityRepository
    {
        void AddorUpdate(LogFrame3rdStepModel model);
        bool IsExist(int projectId);
        LogFrame3rdStepModel Get(int projectId);

    }
}