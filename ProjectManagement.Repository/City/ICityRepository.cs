using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface ICityRepository
    {
        void Add(CityAddModel model);
        void Delete(int cityId);
        bool IsRelatedDataExist(int cityId);
        bool IsNull(int cityId);
        bool IsExist(int stateId, string city);
        bool IsExist(int stateId, string city, int updateId);
        List<CityViewModel> List(int stateId);
        List<DDL> Ddl(int stateId);
        void Edit(CityEditModel model);
        CountryStateByCityModel GetCountryStateByCity(int cityId);
    }
}