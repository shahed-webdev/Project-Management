using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public class ReportTypeCore : CoreDependencies, IReportTypeCore
    {
        public ReportTypeCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse Add(ReportTypeAddModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.ReportName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.ReportType.IsExist(model.ReportName))
                    return new DbResponse(false, $"'{model.ReportName}' already Exist");

                _db.ReportType.Add(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }

        }

        public DbResponse Delete(int reportTypeId)
        {
            try
            {
                if (_db.ReportType.IsNull(reportTypeId))
                    return new DbResponse(false, "Invalid Data");

                if (_db.ReportType.IsRelatedDataExist(reportTypeId))
                    return new DbResponse(false, $"Already use in Project");

                _db.ReportType.Delete(reportTypeId);
                _db.SaveChanges();

                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse Edit(ReportTypeViewModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.ReportName))
                    return new DbResponse(false, "Invalid Data");

                if (_db.ReportType.IsExist(model.ReportName, model.ReportTypeId))
                    return new DbResponse(false, $"'{model.ReportName}' already Exist");

                _db.ReportType.Edit(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<List<ReportTypeViewModel>> List()
        {
            try
            {
                var data = _db.ReportType.List();
                return new DbResponse<List<ReportTypeViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<ReportTypeViewModel>>(false, e.Message);
            }
        }

        public DbResponse<List<DDL>> Ddl()
        {
            try
            {
                var data = _db.ReportType.Ddl();
                return new DbResponse<List<DDL>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<DDL>>(false, e.Message);
            }
        }
    }
}