using ProjectManagement.ViewModel;

namespace ProjectManagement.Repository
{
    public interface ILogFrame3rdStepActivityRepository
    {
        void AddorUpdate(LogFrame3rdStepModel model);
        void Delete(int projectId);
        bool IsExist(int projectId);
        LogFrame3rdStepModel Get(int projectId);

    }
}