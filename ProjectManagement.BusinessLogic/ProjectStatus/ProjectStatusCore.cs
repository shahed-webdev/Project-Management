using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public class ProjectStatusCore : CoreDependencies, IProjectStatusCore
    {
        public ProjectStatusCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse Add(ProjectStatusAddModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.Status))
                    return new DbResponse(false, "Invalid Data");

                if (_db.ProjectStatus.IsExist(model.Status))
                    return new DbResponse(false, $"'{model.Status}' already Exist");

                _db.ProjectStatus.Add(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse Edit(ProjectStatusViewModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.Status))
                    return new DbResponse(false, "Invalid Data");

                if (_db.ProjectStatus.IsExist(model.Status, model.ProjectStatusId))
                    return new DbResponse(false, $"'{model.Status}' already Exist");

                _db.ProjectStatus.Edit(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<List<ProjectStatusViewModel>> List()
        {
            try
            {
                var data = _db.ProjectStatus.List();
                return new DbResponse<List<ProjectStatusViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<ProjectStatusViewModel>>(false, e.Message);
            }
        }

        public DbResponse<List<DDL>> Ddl()
        {
            try
            {
                var data = _db.ProjectStatus.Ddl();
                return new DbResponse<List<DDL>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<DDL>>(false, e.Message);
            }
        }
    }
}