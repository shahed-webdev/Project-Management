using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IProjectBeneficiaryTypeRepository
    {
        void Add(ProjectBeneficiaryTypeAddModel model);
        bool IsExist(string status);
        List<ProjectBeneficiaryTypeViewModel> List();
        List<DDL> Ddl();
    }
}