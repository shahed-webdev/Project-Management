using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class ProjectBeneficiaryTypeRepository : Repository, IProjectBeneficiaryTypeRepository
    {
        public ProjectBeneficiaryTypeRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void Add(ProjectBeneficiaryTypeAddModel model)
        {
            var beneficiaryType = _mapper.Map<ProjectBeneficiaryType>(model);
            Db.ProjectBeneficiaryType.Add(beneficiaryType);
        }

        public void Edit(ProjectBeneficiaryTypeViewModel model)
        {
            var beneficiaryType = Db.ProjectBeneficiaryType.Find(model.ProjectBeneficiaryTypeId);
            if (beneficiaryType == null) return;

            beneficiaryType.BeneficiaryType = model.BeneficiaryType;
            Db.ProjectBeneficiaryType.Update(beneficiaryType);
        }

        public bool IsExist(string beneficiaryType)
        {
            return Db.ProjectBeneficiaryType.Any(c => c.BeneficiaryType == beneficiaryType);
        }

        public bool IsExist(string beneficiaryType, int updateId)
        {
            return Db.ProjectBeneficiaryType.Any(c => c.BeneficiaryType == beneficiaryType && c.ProjectBeneficiaryTypeId != updateId);
        }

        public List<ProjectBeneficiaryTypeViewModel> List()
        {
            return Db.ProjectBeneficiaryType
                .ProjectTo<ProjectBeneficiaryTypeViewModel>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.BeneficiaryType)
                .ToList();
        }

        public List<DDL> Ddl()
        {
            return Db.ProjectBeneficiaryType
                .OrderBy(p => p.BeneficiaryType)
                .Select(s => new DDL
                {
                    label = s.BeneficiaryType,
                    value = s.ProjectBeneficiaryTypeId.ToString()
                })
                .ToList();
        }
    }
}