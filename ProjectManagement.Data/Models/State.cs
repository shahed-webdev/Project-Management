using System.Collections.Generic;

namespace ProjectManagement.Data
{

    public class State
    {
        public State()
        {
            Cities = new HashSet<City>();
        }

        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }

        public ICollection<City> Cities { get; set; }
        public Country Country { get; set; }
    }
}
