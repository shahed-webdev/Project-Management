using ProjectManagement.ViewModel;

namespace ProjectManagement.Repository
{
    public interface ILogFrame2ndStepOutputRepository
    {
        void AddorUpdate(LogFrame2ndStepModel model);
        void Delete(int projectId);
        bool IsExist(int projectId);
        LogFrame2ndStepModel Get(int projectId);

    }
}