using System;
using System.Collections.Generic;
using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.Activity;

public interface IActivityReportService : IReportService
{
    List<ActivityNameViewModel> GetActivityNames(Guid salonGuid);
    List<ActivityReportViewModel> GetActivityReport(ActivityReportSearchModel searchModel);
}