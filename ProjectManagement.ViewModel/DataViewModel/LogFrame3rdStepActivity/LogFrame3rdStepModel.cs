using System;
using System.Collections.Generic;

namespace ProjectManagement.ViewModel
{
    public class LogFrame3rdStepModel
    {
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
        public ICollection<LogFrameParticipantsModel> ProjectParticipants { get; set; }
    }
}