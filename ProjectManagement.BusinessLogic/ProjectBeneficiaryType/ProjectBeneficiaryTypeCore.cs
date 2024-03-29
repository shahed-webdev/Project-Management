﻿using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public class ProjectBeneficiaryTypeCore : CoreDependencies, IProjectBeneficiaryTypeCore
    {
        public ProjectBeneficiaryTypeCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse Add(ProjectBeneficiaryTypeAddModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.BeneficiaryType))
                    return new DbResponse(false, "Invalid Data");

                if (_db.ProjectBeneficiaryType.IsExist(model.BeneficiaryType))
                    return new DbResponse(false, $"'{model.BeneficiaryType}' already Exist");

                _db.ProjectBeneficiaryType.Add(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse Delete(int beneficiaryTypeId)
        {
            try
            {
                if (_db.ProjectBeneficiaryType.IsNull(beneficiaryTypeId))
                    return new DbResponse(false, "Invalid Data");

                if (_db.ProjectBeneficiaryType.IsRelatedDataExist(beneficiaryTypeId))
                    return new DbResponse(false, $"Already use in Project");

                _db.ProjectBeneficiaryType.Delete(beneficiaryTypeId);
                _db.SaveChanges();

                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse Edit(ProjectBeneficiaryTypeViewModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.BeneficiaryType))
                    return new DbResponse(false, "Invalid Data");

                if (_db.ProjectBeneficiaryType.IsExist(model.BeneficiaryType, model.ProjectBeneficiaryTypeId))
                    return new DbResponse(false, $"'{model.BeneficiaryType}' already Exist");

                _db.ProjectBeneficiaryType.Edit(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<List<ProjectBeneficiaryTypeViewModel>> List()
        {
            try
            {
                var data = _db.ProjectBeneficiaryType.List();
                return new DbResponse<List<ProjectBeneficiaryTypeViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<ProjectBeneficiaryTypeViewModel>>(false, e.Message);
            }
        }

        public DbResponse<List<DDL>> Ddl()
        {
            try
            {
                var data = _db.ProjectBeneficiaryType.Ddl();
                return new DbResponse<List<DDL>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<DDL>>(false, e.Message);
            }
        }
    }
}