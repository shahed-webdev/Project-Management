﻿using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IProjectBeneficiaryTypeRepository
    {
        void Add(ProjectBeneficiaryTypeAddModel model);
        void Delete(int beneficiaryTypeId);
        bool IsRelatedDataExist(int beneficiaryTypeId);
        bool IsNull(int beneficiaryTypeId);
        void Edit(ProjectBeneficiaryTypeViewModel model);
        bool IsExist(string beneficiaryType);
        bool IsExist(string beneficiaryType, int updateId);
        List<ProjectBeneficiaryTypeViewModel> List();
        List<DDL> Ddl();
    }
}