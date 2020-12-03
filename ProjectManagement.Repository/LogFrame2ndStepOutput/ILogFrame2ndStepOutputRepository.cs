using ProjectManagement.ViewModel;

namespace ProjectManagement.Repository
{
    public interface ILogFrame2ndStepOutputRepository
    {
        void AddorUpdate(LogFrame2ndStepModel model);
        bool IsExist(int projectId);
        LogFrame2ndStepModel Get(int projectId);

    }
}