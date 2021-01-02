namespace ProjectManagement.Data
{
    public class ProjectCity
    {
        public int ProjectCityId { get; set; }
        public int ProjectId { get; set; }
        public int CityId { get; set; }
        public Project Project { get; set; }
        public City City { get; set; }
    }
}