﻿using AutoMapper;
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

        public bool IsExist(string beneficiaryType)
        {
            return Db.ProjectBeneficiaryType.Any(c => c.BeneficiaryType == beneficiaryType);
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
                    value = s.BeneficiaryType,
                    label = s.ProjectBeneficiaryTypeId.ToString()
                })
                .ToList();
        }
    }
}