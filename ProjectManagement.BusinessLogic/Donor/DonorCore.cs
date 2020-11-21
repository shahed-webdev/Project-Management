using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.BusinessLogic
{
    public class DonorCore : CoreDependencies, IDonorCore
    {
        public DonorCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse Add(DonorAddModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Email))
                    return new DbResponse(false, "Invalid Data");

                if (_db.Donor.IsExistEmail(model.Email))
                    return new DbResponse(false, $"'{model.Email}' already Exist");

                _db.Donor.Add(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse Edit(DonorViewModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Email))
                    return new DbResponse(false, "Invalid Data");

                if (_db.Donor.IsExistEmail(model.Email, model.DonorId))
                    return new DbResponse(false, $"'{model.Email}' already Exist");

                _db.Donor.Edit(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<List<DonorViewModel>> List()
        {
            try
            {
                var data = _db.Donor.List();
                return new DbResponse<List<DonorViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<DonorViewModel>>(false, e.Message);
            }
        }

        public DbResponse<List<DDL>> Ddl()
        {
            try
            {
                var data = _db.Donor.Ddl();
                return new DbResponse<List<DDL>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<DDL>>(false, e.Message);
            }
        }

        public async Task<DbResponse<ICollection<DonorViewModel>>> SearchAsync(string key)
        {
            try
            {
                var data = await _db.Donor.SearchAsync(key);
                return new DbResponse<ICollection<DonorViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<ICollection<DonorViewModel>>(false, e.Message);
            }
        }
    }
}