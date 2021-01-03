namespace ProjectManagement.Data
{
    public class LogFrame2ndStepCity
    {
        public int LogFrame2ndStepCityId { get; set; }
        public int LogFrame2ndStepOutputId { get; set; }
        public int CityId { get; set; }
        public LogFrame2ndStepOutput LogFrame2ndStepOutput { get; set; }
        public City City { get; set; }
    }
}