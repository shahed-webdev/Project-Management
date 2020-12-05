using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class RegistrationRepository : Repository, IRegistrationRepository
    {
        public RegistrationRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public int GetRegID_ByUserName(string userName)
        {
            return Db.Registration.FirstOrDefault(r => r.UserName == userName)?.RegistrationId ?? 0;
        }

        public UserType UserTypeByUserName(string userName)
        {
            return Db.Registration.FirstOrDefault(r => r.UserName == userName).Type;
        }

        public void AddSubAdmin(SubAdminRegisterViewModel model)
        {
            var registration = _mapper.Map<Registration>(model);

            Db.Registration.Add(registration);
            Db.SaveChanges();
        }

        public List<UserViewModel> UserList()
        {
            var list = Db.Registration
                .Where(r => r.Type != UserType.Admin)
                .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
                .ToList();
            return list;
        }

        public List<DDL> UserTypeDdl()
        {
            var list = from UserType a in Enum.GetValues(typeof(UserType))
                       select
                           new DDL
                           {
                               label = a.GetDescription(),
                               value = a.ToString()
                           };
            return list.Where(l => l.value != UserType.Admin.ToString()).ToList();
        }

        public DbResponse ToggleActivation(int registrationId)
        {
            try
            {
                var registration = Db.Registration.Find(registrationId);
                if (registration == null)
                    return new DbResponse(false, "No found");
                var IsDeactivated = registration.IsDeactivated;

                registration.IsDeactivated = !IsDeactivated;
                Db.Registration.Update(registration);
                Db.SaveChanges();


                return new DbResponse(true, $"{registration.UserName} " + (IsDeactivated ? "Activated" : "Deactivated"));
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public bool IsDeactivated(string userName)
        {
            return Db.Registration.FirstOrDefault(r => r.UserName == userName)?.IsDeactivated ?? true;
        }
    }
}