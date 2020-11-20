using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public interface IProjectBeneficiaryTypeCore
    {
        DbResponse Add(ProjectBeneficiaryTypeAddModel model);
        DbResponse<List<ProjectBeneficiaryTypeViewModel>> List();
        DbResponse<List<DDL>> Ddl();
    }
}