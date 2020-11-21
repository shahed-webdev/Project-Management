using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class ReportTypeRepository : Repository, IReportTypeRepository
    {
        public ReportTypeRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void Add(ReportTypeAddModel model)
        {
            var reportType = _mapper.Map<ReportType>(model);
            Db.ReportType.Add(reportType);
        }

        public void Edit(ReportTypeViewModel model)
        {
            var reportType = Db.ReportType.Find(model.ReportTypeId);
            if (reportType == null) return;

            reportType.ReportName = model.ReportName;
            Db.ReportType.Update(reportType);
        }

        public bool IsExist(string reportName)
        {
            return Db.ReportType.Any(c => c.ReportName == reportName);
        }

        public bool IsExist(string reportName, int updateId)
        {
            return Db.ReportType.Any(c => c.ReportName == reportName && c.ReportTypeId != updateId);
        }

        public List<ReportTypeViewModel> List()
        {
            return Db.ProjectBeneficiaryType
                .ProjectTo<ReportTypeViewModel>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.ReportName)
                .ToList();
        }

        public List<DDL> Ddl()
        {
            return Db.ReportType
                .OrderBy(p => p.ReportName)
                .Select(s => new DDL
                {
                    label = s.ReportName,
                    value = s.ReportTypeId.ToString()
                })
                .ToList();
        }
    }
}