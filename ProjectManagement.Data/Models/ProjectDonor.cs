namespace ProjectManagement.Data
{
    public class ProjectDonor
    {
        public int ProjectDonorId { get; set; }
        public int ProjectId { get; set; }
        public int DonorId { get; set; }
        public Project Project { get; set; }
        public Donor Donor { get; set; }
    }
}