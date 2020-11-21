using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.Repository
{
    public class CountryRepository : Repository, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}