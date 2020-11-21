using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public class ProjectSectorCore : CoreDependencies, IProjectSectorCore
    {
        public ProjectSectorCore(IMapper mapper, IUnitOfWork db) : base(mapper, db)
        {
        }

        public DbResponse Add(ProjectSectorAddModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.Sector))
                    return new DbResponse(false, "Invalid Data");

                if (_db.ProjectSector.IsExist(model.Sector))
                    return new DbResponse(false, "Sector Name already Exist");

                _db.ProjectSector.Add(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse Edit(ProjectSectorViewModel model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.Sector))
                    return new DbResponse(false, "Invalid Data");

                if (_db.ProjectSector.IsExist(model.Sector, model.ProjectSectorId))
                    return new DbResponse(false, $"{model.Sector} already Exist");

                _db.ProjectSector.Edit(model);
                _db.SaveChanges();


                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse<List<ProjectSectorViewModel>> List()
        {
            try
            {
                var data = _db.ProjectSector.List();
                return new DbResponse<List<ProjectSectorViewModel>>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<List<ProjectSectorViewModel>>(false, e.Message);
            }
        }

        public DbResponse<ProjectSectorViewModel> Get(int sectorId)
        {
            try
            {
                var data = _db.ProjectSector.Get(sectorId);
                if (data == null)
                    return new DbResponse<ProjectSectorViewModel>(false, "Invalid ID");

                return new DbResponse<ProjectSectorViewModel>(true, "Success", data);
            }
            catch (Exception e)
            {
                return new DbResponse<ProjectSectorViewModel>(false, e.Message);
            }
        }
    }
}