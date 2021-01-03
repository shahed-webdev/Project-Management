using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class CountryRepository : Repository, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void Add(CountryAddModel model)
        {
            var country = _mapper.Map<Country>(model);
            Db.Country.Add(country);
        }

        public void Delete(int countryId)
        {
            var country = Db.Country.Find(countryId);
            Db.Country.Remove(country);
        }

        public bool IsRelatedDataExist(int countryId)
        {
            return Db.State.Any(s => s.CountryId == countryId);
        }

        public bool IsNull(int countryId)
        {
            return !Db.Country.Any(c => c.CountryId == countryId);
        }

        public bool IsExist(string country)
        {
            return Db.Country.Any(c => c.CountryName == country);
        }

        public bool IsExist(string country, int updateId)
        {
            return Db.Country.Any(c => c.CountryName == country && c.CountryId != updateId);
        }

        public List<CountryViewModel> List()
        {
            return Db.Country
                .ProjectTo<CountryViewModel>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.CountryName)
                .ToList();
        }

        public List<DDL> Ddl()
        {
            return Db.Country
                .OrderBy(p => p.CountryName)
                .Select(s => new DDL
                {
                    value = s.CountryId.ToString(),
                    label = s.CountryName
                })
                .ToList();
        }

        public void Edit(CountryViewModel model)
        {
            var country = Db.Country.Find(model.CountryId);

            if (country == null) return;

            country.CountryName = model.CountryName;
            Db.Country.Update(country);
        }
    }
}