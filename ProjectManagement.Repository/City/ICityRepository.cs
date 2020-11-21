using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface ICityRepository
    {
        void Add(CityAddModel model);
        bool IsNull(int id);
        bool IsExist(int stateId, string city);
        bool IsExist(int stateId, string city, int updateId);
        List<CityViewModel> List(int stateId);
        List<DDL> Ddl(int stateId);
        void Edit(CityViewModel model);
    }
}