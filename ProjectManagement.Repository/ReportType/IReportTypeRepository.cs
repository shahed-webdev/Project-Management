using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IReportTypeRepository
    {
        void Add(ReportTypeAddModel model);
        void Edit(ReportTypeViewModel model);
        bool IsExist(string beneficiaryType);
        bool IsExist(string beneficiaryType, int updateId);
        List<ReportTypeViewModel> List();
        List<DDL> Ddl();

    }
}