using ProjectManagement.Data;

namespace ProjectManagement.Repository
{
    public interface IRegistrationRepository
    {
        int GetRegID_ByUserName(string userName);
        UserType UserTypeByUserName(string userName);
    }
}