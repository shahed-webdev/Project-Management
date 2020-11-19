using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class Donor
    {
        public Donor()
        {
            ProjectDonors = new HashSet<ProjectDonor>();
        }
        public int DonorId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<ProjectDonor> ProjectDonors { get; set; }

    }
}