using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface ICountryRepository
    {
        void Add(CountryAddModel model);
        void Delete(int countryId);
        bool IsRelatedDataExist(int countryId);
        bool IsNull(int countryId);
        bool IsExist(string country);
        bool IsExist(string country, int updateId);
        List<CountryViewModel> List();
        List<DDL> Ddl();
        void Edit(CountryViewModel model);
    }
}