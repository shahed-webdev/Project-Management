using System.Collections.Generic;

namespace ProjectManagement.Data
{

    public class City
    {
        public City()
        {
            LogFrame1stStepCities = new HashSet<LogFrame1stStepCity>();
            LogFrame2ndStepCities = new HashSet<LogFrame2ndStepCity>();
            LogFrame3rdStepCities = new HashSet<LogFrame3rdStepCity>();
            ProjectCities = new HashSet<ProjectCity>();
        }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
        public State State { get; set; }
        public ICollection<LogFrame1stStepCity> LogFrame1stStepCities { get; set; }
        public ICollection<LogFrame2ndStepCity> LogFrame2ndStepCities { get; set; }
        public ICollection<LogFrame3rdStepCity> LogFrame3rdStepCities { get; set; }
        public ICollection<ProjectCity> ProjectCities { get; set; }
    }
}
