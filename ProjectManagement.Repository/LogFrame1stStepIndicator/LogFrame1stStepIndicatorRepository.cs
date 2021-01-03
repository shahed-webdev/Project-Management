using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class LogFrame1stStepIndicatorRepository : Repository, ILogFrame1stStepIndicatorRepository
    {
        public LogFrame1stStepIndicatorRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void AddorUpdate(LogFrame1stStepModel model)
        {
            if (IsExist(model.ProjectId))
            {
                var log = Db.LogFrame1stStepIndicator
                    .Include(l => l.LogFrame1stStepParticipants)
                    .Include(l => l.LogFrame1stStepCities)
                    .FirstOrDefault(l => l.ProjectId == model.ProjectId);

                log.ProjectId = model.ProjectId;
                log.LogFrame1stStepCities = model.CityIds is null ? new List<LogFrame1stStepCity>() : model.CityIds.Select(c => new LogFrame1stStepCity { CityId = c }).ToList();
                log.ProjectGoal = model.ProjectGoal;
                log.ResultBaseIndicator = model.ResultBaseIndicator;
                log.Outcome = model.Outcome;
                log.OutcomeBaseIndicator = model.OutcomeBaseIndicator;
                log.BaselineValue = model.BaselineValue;
                log.TargetValue = model.TargetValue;
                log.AchieveValue = model.AchieveValue;
                log.MeasuringUnit = model.MeasuringUnit;
                log.BaselineDate = model.BaselineDate;
                log.Date1 = model.Date1;
                log.Date2 = model.Date2;
                log.Frequency1 = model.Frequency1;
                log.Frequency2 = model.Frequency2;
                log.Location = model.Location;
                log.PrimarySource = model.PrimarySource;
                log.LogFrame1stStepParticipants = model.ProjectParticipants is null ? new List<LogFrame1stStepParticipant>() : model.ProjectParticipants
                    .Select(p => _mapper.Map<LogFrame1stStepParticipant>(p)).ToList();
                Db.LogFrame1stStepIndicator.Update(log);
            }
            else
            {
                var log = _mapper.Map<LogFrame1stStepIndicator>(model);
                Db.LogFrame1stStepIndicator.Add(log);
            }
        }

        public void Delete(int projectId)
        {
            var logs = Db.LogFrame1stStepIndicator.Where(l => l.ProjectId == projectId).ToList();
            Db.LogFrame1stStepIndicator.RemoveRange(logs);
        }

        public bool IsExist(int projectId)
        {
            return Db.LogFrame1stStepIndicator.Any(l => l.ProjectId == projectId);
        }

        public LogFrame1stStepModel Get(int projectId)
        {
            var log = Db.LogFrame1stStepIndicator
                .Where(l => l.ProjectId == projectId)
                .ProjectTo<LogFrame1stStepModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return log;
        }
    }
}