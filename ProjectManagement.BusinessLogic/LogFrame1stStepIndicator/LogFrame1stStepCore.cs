using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;

namespace ProjectManagement.BusinessLogic
{
    public class LogFrame1stStepCore : CoreDependencies, ILogFrame1stStepCore
    {
        public LogFrame1stStepCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse AddorUpdate(LogFrame1stStepModel model)
        {
            try
            {
                _db.LogFrame1stStepIndicator.AddorUpdate(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<LogFrame1stStepModel> Get(int projectId)
        {
            try
            {
                var data = _db.LogFrame1stStepIndicator.Get(projectId);

                if (data == null)
                    return new DbResponse<LogFrame1stStepModel>(false, "No Data Found");

                return new DbResponse<LogFrame1stStepModel>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<LogFrame1stStepModel>(false, e.Message);
            }

        }
    }
}