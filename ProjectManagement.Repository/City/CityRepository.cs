using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.Repository
{
    public class CityRepository : Repository, ICityRepository
    {
        public CityRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}