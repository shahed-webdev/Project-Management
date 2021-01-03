namespace ProjectManagement.Data
{
    public class LogFrame3rdStepCity
    {
        public int LogFrame3rdStepCityId { get; set; }
        public int LogFrame3rdStepActivityId { get; set; }
        public int CityId { get; set; }
        public LogFrame3rdStepActivity LogFrame3rdStepActivity { get; set; }
        public City City { get; set; }
    }
}