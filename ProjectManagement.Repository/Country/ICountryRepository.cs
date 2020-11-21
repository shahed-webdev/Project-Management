using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface ICountryRepository
    {
        void Add(CountryAddModel model);
        bool IsNull(int id);
        bool IsExist(string country);
        bool IsExist(string country, int updateId);
        List<CountryViewModel> List();
        List<DDL> Ddl();
        void Edit(CountryViewModel model);
    }
}