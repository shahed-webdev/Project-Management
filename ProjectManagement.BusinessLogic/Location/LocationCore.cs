using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public class LocationCore : CoreDependencies, ILocationCore
    {
        public LocationCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse CountryAdd(CountryAddModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.CountryName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.Country.IsExist(model.CountryName))
                    return new DbResponse(false, $"'{model.CountryName}' already Exist");

                _db.Country.Add(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse CountryDelete(int countryId)
        {
            try
            {
                if (_db.Country.IsNull(countryId))
                    return new DbResponse(false, "Invalid Data");

                if (_db.Country.IsRelatedDataExist(countryId))
                    return new DbResponse(false, $"Already use in State");

                _db.Country.Delete(countryId);
                _db.SaveChanges();

                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse CountryEdit(CountryViewModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.CountryName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.Country.IsExist(model.CountryName, model.CountryId))
                    return new DbResponse(false, $"'{model.CountryName}' already Exist");

                _db.Country.Edit(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<List<CountryViewModel>> CountryList()
        {
            try
            {
                var data = _db.Country.List();
                return new DbResponse<List<CountryViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<CountryViewModel>>(false, e.Message);
            }
        }

        public DbResponse<List<DDL>> CountryDdl()
        {
            try
            {
                var data = _db.Country.Ddl();
                return new DbResponse<List<DDL>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<DDL>>(false, e.Message);
            }
        }

        public DbResponse StateAdd(StateAddModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.StateName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.State.IsExist(model.CountryId, model.StateName))
                    return new DbResponse(false, $"'{model.StateName}' already Exist");

                _db.State.Add(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse StateDelete(int stateId)
        {
            try
            {
                if (_db.State.IsNull(stateId))
                    return new DbResponse(false, "Invalid Data");

                if (_db.State.IsRelatedDataExist(stateId))
                    return new DbResponse(false, $"Already use in City");

                _db.State.Delete(stateId);
                _db.SaveChanges();

                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse StateEdit(StateEditModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.StateName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.State.IsExist(model.CountryId, model.StateName, model.StateId))
                    return new DbResponse(false, $"'{model.StateName}' already Exist");

                _db.State.Edit(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<List<StateViewModel>> StateList(int countryId)
        {

            try
            {
                var data = _db.State.List(countryId);
                return new DbResponse<List<StateViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<StateViewModel>>(false, e.Message);
            }
        }

        public DbResponse<List<DDL>> StateDdl(int countryId)
        {
            try
            {
                var data = _db.State.Ddl(countryId);
                return new DbResponse<List<DDL>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<DDL>>(false, e.Message);
            }
        }

        public DbResponse CityAdd(CityAddModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.CityName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.City.IsExist(model.StateId, model.CityName))
                    return new DbResponse(false, $"'{model.CityName}' already Exist");

                _db.City.Add(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse CityDelete(int cityId)
        {
            try
            {
                if (_db.City.IsNull(cityId))
                    return new DbResponse(false, "Invalid Data");

                if (_db.City.IsRelatedDataExist(cityId))
                    return new DbResponse(false, $"Already use in projects");

                _db.City.Delete(cityId);
                _db.SaveChanges();

                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse CityEdit(CityEditModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.CityName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.City.IsExist(model.StateId, model.CityName, model.CityId))
                    return new DbResponse(false, $"'{model.CityName}' already Exist");

                _db.City.Edit(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<List<CityViewModel>> CityList(int stateId)
        {
            try
            {
                var data = _db.City.List(stateId);
                return new DbResponse<List<CityViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<CityViewModel>>(false, e.Message);
            }
        }

        public DbResponse<List<DDL>> CityDdl(int stateId)
        {
            try
            {
                var data = _db.City.Ddl(stateId);
                return new DbResponse<List<DDL>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<DDL>>(false, e.Message);
            }
        }

        public DbResponse<CountryStateByCityModel> GetCountryStateByCity(int cityId)
        {
            try
            {
                var data = _db.City.GetCountryStateByCity(cityId);
                data.Countries = _db.Country.Ddl();
                data.States = _db.State.Ddl(data.CountryId);
                data.Cities = _db.City.Ddl(data.StateId);


                return new DbResponse<CountryStateByCityModel>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<CountryStateByCityModel>(false, e.Message);
            }
        }
    }
}