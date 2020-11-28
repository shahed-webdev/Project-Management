using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class LogFrameRepository : Repository, ILogFrameRepository
    {
        public LogFrameRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void AddorUpdate(LogFrameModel model)
        {
            if (IsExist(model.ProjectId))
            {
                var log = Db.LogFrame.FirstOrDefault(l => l.ProjectId == model.ProjectId);

                log.Activity = model.Activity;
                log.Outcome = model.Outcome;
                log.OutcomeBaseIndicator = model.OutcomeBaseIndicator;
                log.Output = model.Output;
                log.OutputBaseIndicator = model.OutputBaseIndicator;
                log.ProjectGoal = model.ProjectGoal;
                log.ResultBaseIndicator = model.ResultBaseIndicator;

                Db.LogFrame.Update(log);
            }
            else
            {
                var log = _mapper.Map<LogFrame>(model);
                Db.LogFrame.Add(log);
            }
        }

        public bool IsExist(int projectId)
        {
            return Db.LogFrame.Any(l => l.ProjectId == projectId);
        }

        public LogFrameModel Get(int projectId)
        {
            var log = Db.LogFrame
                .Where(l => l.ProjectId == projectId)
                .ProjectTo<LogFrameModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return log;
        }
    }
}