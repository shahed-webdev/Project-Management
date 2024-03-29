﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProjectManagement.Data;
using ProjectManagement.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Repository
{
    public class ProjectStatusRepository : Repository, IProjectStatusRepository
    {
        public ProjectStatusRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public void Add(ProjectStatusAddModel model)
        {
            var status = _mapper.Map<ProjectStatus>(model);
            Db.ProjectStatus.Add(status);
        }

        public void Delete(int projectStatusId)
        {
            var status = Db.ProjectStatus.Find(projectStatusId);
            Db.ProjectStatus.Remove(status);
        }

        public bool IsRelatedDataExist(int projectStatusId)
        {
            return Db.Project.Any(p => p.ProjectStatusId == projectStatusId);
        }

        public void Edit(ProjectStatusViewModel model)
        {
            var status = Db.ProjectStatus.Find(model.ProjectStatusId);
            if (status == null) return;
            status.Status = model.Status;
            Db.ProjectStatus.Update(status);
        }

        public bool IsNull(int projectStatusId)
        {
            return !Db.ProjectStatus.Any(s => s.ProjectStatusId == projectStatusId);
        }

        public bool IsExist(string status)
        {
            return Db.ProjectStatus.Any(c => c.Status == status);
        }

        public bool IsExist(string status, int updateId)
        {
            return Db.ProjectStatus.Any(c => c.Status == status && c.ProjectStatusId != updateId);
        }

        public List<ProjectStatusViewModel> List()
        {
            return Db.ProjectStatus
                .ProjectTo<ProjectStatusViewModel>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.Status)
                .ToList();
        }

        public List<DDL> Ddl()
        {
            return Db.ProjectStatus
                .OrderBy(p => p.Status)
                .Select(s => new DDL
                {
                    value = s.ProjectStatusId.ToString(),
                    label = s.Status
                })
                .ToList();
        }
    }
}