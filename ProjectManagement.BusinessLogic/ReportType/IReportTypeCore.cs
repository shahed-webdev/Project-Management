﻿using ProjectManagement.ViewModel;
using System.Collections.Generic;

namespace ProjectManagement.BusinessLogic
{
    public interface IReportTypeCore
    {
        DbResponse Add(ReportTypeAddModel model);
        DbResponse Delete(int reportTypeId);
        DbResponse Edit(ReportTypeViewModel model);
        DbResponse<List<ReportTypeViewModel>> List();
        DbResponse<List<DDL>> Ddl();


    }
}