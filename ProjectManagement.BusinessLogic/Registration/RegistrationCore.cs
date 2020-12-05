using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public class RegistrationCore : CoreDependencies, IRegistrationCore
    {
        public RegistrationCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse AddSubAdmin(SubAdminRegisterViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.UserName))
                    return new DbResponse(false, "Invalid data");

                _db.Registration.AddSubAdmin(model);
                _db.SaveChanges();

                return new DbResponse(true, "Success");

            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<List<UserViewModel>> UserList()
        {
            try
            {
                var data = _db.Registration.UserList();

                return new DbResponse<List<UserViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<UserViewModel>>(false, e.Message);
            }
        }

        public DbResponse<List<DDL>> UserTypeDdl()
        {
            try
            {

                var data = _db.Registration.UserTypeDdl();

                return new DbResponse<List<DDL>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<DDL>>(false, e.Message);
            }
        }

        public DbResponse ToggleActivation(int registrationId)
        {
            return _db.Registration.ToggleActivation(registrationId);
        }
    }
}