using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface ICountryRepository
    {
        void Add(CountryAddModel model);
        bool IsExist(string sector);
        List<CountryViewModel> List();
    }

    public class CountryViewModel
    {
    }

    public class CountryAddModel
    {
    }
}