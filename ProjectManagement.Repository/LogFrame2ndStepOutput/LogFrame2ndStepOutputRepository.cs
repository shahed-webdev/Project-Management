﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class LogFrame2ndStepOutputRepository : Repository, ILogFrame2ndStepOutputRepository
    {
        public LogFrame2ndStepOutputRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void AddorUpdate(LogFrame2ndStepModel model)
        {
            if (IsExist(model.ProjectId))
            {
                var log = Db.LogFrame2ndStepOutput
                    .Include(l => l.LogFrame2ndStepParticipants)
                    .Include(l => l.LogFrame2ndStepCities)
                    .FirstOrDefault(l => l.ProjectId == model.ProjectId);

                log.ProjectId = model.ProjectId;
                log.LogFrame2ndStepCities = model.CityIds is null ? new List<LogFrame2ndStepCity>() : model.CityIds.Select(c => new LogFrame2ndStepCity { CityId = c }).ToList();
                log.Output = model.Output;
                log.OutputBaseIndicator = model.OutputBaseIndicator;
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
                log.LogFrame2ndStepParticipants = model.ProjectParticipants is null ? new List<LogFrame2ndStepParticipant>() : model.ProjectParticipants
                    .Select(p => _mapper.Map<LogFrame2ndStepParticipant>(p)).ToList();

                Db.LogFrame2ndStepOutput.Update(log);
            }
            else
            {
                var log = _mapper.Map<LogFrame2ndStepOutput>(model);
                Db.LogFrame2ndStepOutput.Add(log);
            }
        }

        public void Delete(int projectId)
        {
            var logs = Db.LogFrame2ndStepOutput.Where(l => l.ProjectId == projectId).ToList();
            Db.LogFrame2ndStepOutput.RemoveRange(logs);
        }

        public bool IsExist(int projectId)
        {
            return Db.LogFrame2ndStepOutput.Any(l => l.ProjectId == projectId);
        }

        public LogFrame2ndStepModel Get(int projectId)
        {
            var log = Db.LogFrame2ndStepOutput
                .Where(l => l.ProjectId == projectId)
                .ProjectTo<LogFrame2ndStepModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return log;
        }
    }
}