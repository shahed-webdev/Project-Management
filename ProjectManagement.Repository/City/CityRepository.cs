using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class CityRepository : Repository, ICityRepository
    {
        public CityRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void Add(CityAddModel model)
        {
            var city = _mapper.Map<City>(model);
            Db.City.Add(city);
        }

        public bool IsNull(int id)
        {
            return !Db.City.Any(c => c.CityId == id);
        }

        public bool IsExist(int stateId, string city)
        {
            return Db.City.Any(c => c.StateId == stateId && c.CityName == city);
        }

        public bool IsExist(int stateId, string city, int updateId)
        {
            return Db.City.Any(c => c.StateId == stateId && c.CityName == city && c.CityId != updateId);
        }

        public List<CityViewModel> List(int stateId)
        {
            return Db.City
                .Where(s => s.StateId == stateId)
                .ProjectTo<CityViewModel>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.CityName)
                .ToList();

        }

        public List<DDL> Ddl(int stateId)
        {
            return Db.City
                .Where(s => s.StateId == stateId)
                .OrderBy(p => p.CityName)
                .Select(s => new DDL
                {
                    value = s.CityId.ToString(),
                    label = s.CityName
                })
                .ToList();
        }

        public void Edit(CityViewModel model)
        {
            var city = Db.City.Find(model.CityId);

            if (city == null) return;

            city.CityName = model.CityName;
            Db.City.Update(city);
        }
    }
}