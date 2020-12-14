using System;
using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class LogFrame1stStepIndicator
    {
        public LogFrame1stStepIndicator()
        {
            LogFrame1stStepParticipants = new HashSet<LogFrame1stStepParticipant>();
        }
        public int LogFrame1stStepIndicatorId { get; set; }
        public int ProjectId { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public string ProjectGoal { get; set; }
        public string ResultBaseIndicator { get; set; }
        public string Outcome { get; set; }
        public string OutcomeBaseIndicator { get; set; }
        public decimal? BaselineValue { get; set; }
        public decimal? TargetValue { get; set; }
        public decimal? AchieveValue { get; set; }
        public string MeasuringUnit { get; set; }
        public DateTime? BaselineDate { get; set; }
        public DateTime? Date1 { get; set; }
        public DateTime? Date2 { get; set; }
        public string Frequency1 { get; set; }
        public string Frequency2 { get; set; }
        public string Location { get; set; }
        public string PrimarySource { get; set; }
        public Project Project { get; set; }
        public ICollection<LogFrame1stStepParticipant> LogFrame1stStepParticipants { get; set; }

    }
}