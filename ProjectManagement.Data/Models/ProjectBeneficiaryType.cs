using System.Collections.Generic;

namespace ProjectManagement.Data
{
    public class ProjectBeneficiaryType
    {
        public ProjectBeneficiaryType()
        {
            ProjectBeneficiaries = new HashSet<ProjectBeneficiary>();
        }
        public int ProjectBeneficiaryTypeId { get; set; }
        public string BeneficiaryType { get; set; }
        public ICollection<ProjectBeneficiary> ProjectBeneficiaries { get; set; }
    }
}