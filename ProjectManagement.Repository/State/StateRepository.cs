using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.Repository
{
    public class StateRepository : Repository, IStateRepository
    {
        public StateRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}