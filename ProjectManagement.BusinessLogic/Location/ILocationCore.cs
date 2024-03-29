﻿using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public interface ILocationCore
    {
        DbResponse CountryAdd(CountryAddModel model);
        DbResponse CountryDelete(int countryId);
        DbResponse CountryEdit(CountryViewModel model);
        DbResponse<List<CountryViewModel>> CountryList();
        DbResponse<List<DDL>> CountryDdl();


        DbResponse StateAdd(StateAddModel model);
        DbResponse StateDelete(int stateId);
        DbResponse StateEdit(StateEditModel model);
        DbResponse<List<StateViewModel>> StateList(int countryId);
        DbResponse<List<DDL>> StateDdl(int countryId);


        DbResponse CityAdd(CityAddModel model);
        DbResponse CityDelete(int cityId);
        DbResponse CityEdit(CityEditModel model);
        DbResponse<List<CityViewModel>> CityList(int stateId);
        DbResponse<List<DDL>> CityDdl(int stateId);

        DbResponse<CountryStateByCityModel> GetCountryStateByCity(int cityId);
    }
}