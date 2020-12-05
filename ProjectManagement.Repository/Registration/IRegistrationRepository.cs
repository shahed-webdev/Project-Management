using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IRegistrationRepository
    {
        int GetRegID_ByUserName(string userName);
        UserType UserTypeByUserName(string userName);
        void AddSubAdmin(SubAdminRegisterViewModel model);
        List<UserViewModel> UserList();
        List<DDL> UserTypeDdl();
        DbResponse ToggleActivation(int registrationId);
        bool IsDeactivated(string userName);
    }
}