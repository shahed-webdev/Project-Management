using ProjectManagement.ViewModel;

namespace ProjectManagement.Repository
{
    public interface ILogFrame1stStepIndicatorRepository
    {
        void AddorUpdate(LogFrame1stStepModel model);
        void Delete(int projectId);
        bool IsExist(int projectId);
        LogFrame1stStepModel Get(int projectId);
    }
}