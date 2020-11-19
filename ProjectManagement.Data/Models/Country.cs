using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public ICollection<State> States { get; set; }
    }
}
