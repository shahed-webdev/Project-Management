using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IStateRepository
    {

        void Add(StateAddModel model);
        bool IsNull(int id);
        bool IsExist(int countryId, string state);
        bool IsExist(int countryId, string state, int updateId);
        List<StateViewModel> List(int countryId);
        List<DDL> Ddl(int countryId);
        void Edit(StateViewModel model);
    }
}