namespace ProjectManagement.Data
{
    public class LogFrame1stStepCity
    {
        public int LogFrame1stStepCityId { get; set; }
        public int CityId { get; set; }
        public int LogFrame1stStepIndicatorId { get; set; }
        public LogFrame1stStepIndicator LogFrame1stStepIndicator { get; set; }
        public City City { get; set; }
    }
}