using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public class ProjectCore : CoreDependencies, IProjectCore
    {
        public ProjectCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse Add(ProjectAddModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.Title))
                    return new DbResponse(false, "Invalid Data");

                if (_db.Project.IsExist(model.Title))
                    return new DbResponse(false, $"'{model.Title}' already Exist");

                _db.Project.Add(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse Delete(int projectId)
        {
            try
            {
                if (_db.Project.IsNull(projectId))
                    return new DbResponse(false, "Invalid Data");

                if (_db.Project.IsRelatedDataExist(projectId))
                    return new DbResponse(false, $"Already use in Log Frame");

                _db.Project.Delete(projectId);
                _db.SaveChanges();

                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<ProjectEditViewModel> Get(int projectId)
        {
            try
            {
                var data = _db.Project.Get(projectId);

                if (data == null)
                    return new DbResponse<ProjectEditViewModel>(false, "No Data Found");

                return new DbResponse<ProjectEditViewModel>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<ProjectEditViewModel>(false, e.Message);
            }
        }

        public DbResponse Edit(ProjectEditViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public DbResponse<List<ProjectListViewModel>> List(int sectorId)
        {
            try
            {
                var data = _db.Project.List(sectorId);
                return new DbResponse<List<ProjectListViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<ProjectListViewModel>>(false, e.Message);
            }
        }

        public DbResponse<List<ProjectReportsAddModel>> Reports(int projectId)
        {
            try
            {
                var data = _db.Project.Reports(projectId);
                return data is null ? new DbResponse<List<ProjectReportsAddModel>>(false, "No Data Found") : new DbResponse<List<ProjectReportsAddModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<ProjectReportsAddModel>>(false, e.Message);
            }
        }

        public DbResponse<List<DDL>> Ddl(int sectorId)
        {
            try
            {
                var data = _db.Project.Ddl(sectorId);
                return new DbResponse<List<DDL>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<DDL>>(false, e.Message);
            }
        }

        public DbResponse AddExpediter(ProjectExpediterAddModel model)
        {
            try
            {

                if (_db.Project.IsNull(model.ProjectId))
                    return new DbResponse(false, $"No data Found");

                _db.Project.AddExpediter(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }
    }
}