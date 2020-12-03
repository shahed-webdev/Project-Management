using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;

namespace ProjectManagement.BusinessLogic
{
    public class LogFrame2ndStepOutputCore : CoreDependencies, ILogFrame2ndStepOutputCore
    {
        public LogFrame2ndStepOutputCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse AddorUpdate(LogFrame2ndStepModel model)
        {
            try
            {
                _db.LogFrame2ndStepOutput.AddorUpdate(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<LogFrame2ndStepModel> Get(int projectId)
        {
            try
            {
                var data = _db.LogFrame2ndStepOutput.Get(projectId);

                if (data == null)
                    return new DbResponse<LogFrame2ndStepModel>(false, "No Data Found");

                return new DbResponse<LogFrame2ndStepModel>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<LogFrame2ndStepModel>(false, e.Message);
            }
        }
    }
}