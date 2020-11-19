using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.Repository
{
    public class RegistrationRepository : Repository, IRegistrationRepository
    {
        public RegistrationRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public int GetRegID_ByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }

        public UserType UserTypeByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}