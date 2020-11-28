using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;

namespace ProjectManagement.BusinessLogic
{
    public class LogFrameCore : CoreDependencies, ILogFrameCore
    {
        public LogFrameCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse AddorUpdate(LogFrameModel model)
        {
            try
            {
                if (!_db.LogFrame.IsExist(model.ProjectId))
                    return new DbResponse(false, $"Not Found");

                _db.LogFrame.AddorUpdate(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<LogFrameModel> Get(int projectId)
        {
            try
            {
                var data = _db.LogFrame.Get(projectId);

                if (data == null)
                    return new DbResponse<LogFrameModel>(false, "No Data Found");

                return new DbResponse<LogFrameModel>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<LogFrameModel>(false, e.Message);
            }
        }
    }
}