using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public interface IRegistrationCore
    {
        DbResponse AddSubAdmin(SubAdminRegisterViewModel model);
        DbResponse<List<UserViewModel>> UserList();
        DbResponse<List<DDL>> UserTypeDdl();
        DbResponse ToggleActivation(int registrationId);
    }
}