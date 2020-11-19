﻿namespace ProjectManagement.Data
{
    public class ProjectBeneficiary
    {
        public int ProjectBeneficiaryId { get; set; }
        public int ProjectBeneficiaryTypeId { get; set; }
        public int ProjectId { get; set; }
        public int Count { get; set; }
        public virtual ProjectBeneficiaryType ProjectBeneficiaryType { get; set; }
        public virtual Project Project { get; set; }

    }
}