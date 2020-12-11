using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;

namespace ProjectManagement.BusinessLogic
{
    public class LogFrame3rdStepActivityCore : CoreDependencies, ILogFrame3rdStepActivityCore
    {
        public LogFrame3rdStepActivityCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse AddorUpdate(LogFrame3rdStepModel model)
        {
            try
            {
                _db.LogFrame3rdStepActivity.AddorUpdate(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }
        public DbResponse Delete(int projectId)
        {
            try
            {
                _db.LogFrame3rdStepActivity.Delete(projectId);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }
        public DbResponse<LogFrame3rdStepModel> Get(int projectId)
        {
            try
            {
                var data = _db.LogFrame3rdStepActivity.Get(projectId);

                if (data == null)
                    return new DbResponse<LogFrame3rdStepModel>(false, "No Data Found");

                return new DbResponse<LogFrame3rdStepModel>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<LogFrame3rdStepModel>(false, e.Message);
            }
        }
    }
}