﻿using System;

namespace ProjectManagement.Data
{
    public class LogFrame2ndStepOutput
    {
        public int LogFrame2ndStepOutputId { get; set; }
        public int ProjectId { get; set; }
        public string Output { get; set; }
        public string OutputBaseIndicator { get; set; }
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
        public string Participants { get; set; }
        public string PrimarySource { get; set; }
        public Project Project { get; set; }
    }
}