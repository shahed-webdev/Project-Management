using System.Collections.Generic;

namespace ProjectManagement.ViewModel
{
    public class CountryStateByCityModel
    {
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public ICollection<DDL> Cities { get; set; }
        public ICollection<DDL> States { get; set; }
        public ICollection<DDL> Countries { get; set; }

    }
}