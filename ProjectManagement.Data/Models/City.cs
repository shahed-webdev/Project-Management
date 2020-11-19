using System.Collections.Generic;

namespace ProjectManagement.Data
{

    public class City
    {
        public City()
        {
            Projects = new HashSet<Project>();
        }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }

        public State State { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
