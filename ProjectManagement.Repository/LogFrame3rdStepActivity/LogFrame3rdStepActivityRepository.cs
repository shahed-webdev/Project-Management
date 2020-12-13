using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class LogFrame3rdStepActivityRepository : Repository, ILogFrame3rdStepActivityRepository
    {
        public LogFrame3rdStepActivityRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void AddorUpdate(LogFrame3rdStepModel model)
        {
            if (IsExist(model.ProjectId))
            {
                var log = Db.LogFrame3rdStepActivity.Include(l => l.LogFrame3rdStepParticipants).FirstOrDefault(l => l.ProjectId == model.ProjectId);

                log.ProjectId = model.ProjectId;
                log.CityId = model.CityId;
                log.BaselineValue = model.BaselineValue;
                log.TargetValue = model.TargetValue;
                log.AchieveValue = model.AchieveValue;
                log.MeasuringUnit = model.MeasuringUnit;
                log.BaselineDate = model.BaselineDate;
                log.Date1 = model.Date1;
                log.Date2 = model.Date2;
                log.Frequency1 = model.Frequency1;
                log.Frequency2 = model.Frequency2;
                log.Frequency3 = model.Frequency3;
                log.Location = model.Location;
                log.PrimarySource = model.PrimarySource;
                log.Budget = model.Budget;
                log.Expenditure = model.Expenditure;
                log.CurrencyMeasuringUnit = model.CurrencyMeasuringUnit;
                log.SummaryOrRemarks = model.SummaryOrRemarks;
                log.ReasonOfDeviation = model.ReasonOfDeviation;
                log.LogFrame3rdStepParticipants = model.ProjectParticipants
                    .Select(p => _mapper.Map<LogFrame3rdStepParticipant>(p)).ToList();


                Db.LogFrame3rdStepActivity.Update(log);
            }
            else
            {
                var log = _mapper.Map<LogFrame3rdStepActivity>(model);
                Db.LogFrame3rdStepActivity.Add(log);
            }
        }

        public void Delete(int projectId)
        {
            var logs = Db.LogFrame3rdStepActivity.Where(l => l.ProjectId == projectId).ToList();
            Db.LogFrame3rdStepActivity.RemoveRange(logs);
        }
        public bool IsExist(int projectId)
        {
            return Db.LogFrame3rdStepActivity.Any(l => l.ProjectId == projectId);
        }

        public LogFrame3rdStepModel Get(int projectId)
        {
            var log = Db.LogFrame3rdStepActivity
                .Where(l => l.ProjectId == projectId)
                .ProjectTo<LogFrame3rdStepModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return log;
        }
    }
}