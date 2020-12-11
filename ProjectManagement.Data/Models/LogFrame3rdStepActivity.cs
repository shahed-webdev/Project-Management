using System;
using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class LogFrame3rdStepActivity
    {
        public LogFrame3rdStepActivity()
        {
            LogFrame3rdStepParticipants = new HashSet<LogFrame3rdStepParticipant>();
        }
        public int LogFrame3rdStepActivityId { get; set; }
        public int ProjectId { get; set; }
        public decimal? BaselineValue { get; set; }
        public decimal? TargetValue { get; set; }
        public decimal? AchieveValue { get; set; }
        public string MeasuringUnit { get; set; }
        public DateTime? BaselineDate { get; set; }
        public DateTime? Date1 { get; set; }
        public DateTime? Date2 { get; set; }
        public string Frequency1 { get; set; }
        public string Frequency2 { get; set; }
        public string Frequency3 { get; set; }
        public string Location { get; set; }
        public string PrimarySource { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Expenditure { get; set; }
        public string CurrencyMeasuringUnit { get; set; }
        public string SummaryOrRemarks { get; set; }
        public string ReasonOfDeviation { get; set; }
        public Project Project { get; set; }
        public ICollection<LogFrame3rdStepParticipant> LogFrame3rdStepParticipants { get; set; }
    }

}
