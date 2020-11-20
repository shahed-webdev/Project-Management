﻿using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.Repository
{
    public interface IProjectStatusRepository
    {
        void Add(ProjectStatusAddModel model);
        bool IsExist(string status);
        List<ProjectStatusViewModel> List();
        List<DDL> Ddl();
    }
}