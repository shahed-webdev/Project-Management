using System.Collections.Generic;

namespace ProjectManagement.Data
{

    public class City
    {
        public City()
        {
            LogFrame1stStepIndicators = new HashSet<LogFrame1stStepIndicator>();
            LogFrame2ndStepOutputs = new HashSet<LogFrame2ndStepOutput>();
            LogFrame3rdStepActivities = new HashSet<LogFrame3rdStepActivity>();
            ProjectCities = new HashSet<ProjectCity>();
        }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }

        public State State { get; set; }

        public ICollection<LogFrame1stStepIndicator> LogFrame1stStepIndicators { get; set; }
        public ICollection<LogFrame2ndStepOutput> LogFrame2ndStepOutputs { get; set; }
        public ICollection<LogFrame3rdStepActivity> LogFrame3rdStepActivities { get; set; }
        public ICollection<ProjectCity> ProjectCities { get; set; }
    }
}
