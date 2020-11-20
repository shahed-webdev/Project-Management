using AutoMapper;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public class ProjectSectorCore : IProjectSectorCore
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _db;

        public ProjectSectorCore(IMapper mapper, IUnitOfWork db)
        {
            _mapper = mapper;
            _db = db;
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
    }
}