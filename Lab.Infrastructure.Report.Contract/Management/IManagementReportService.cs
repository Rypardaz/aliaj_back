using System;
using System.Collections.Generic;
using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.Management
{
    public interface IManagementReportService : IReportService
    {
        List<DailyRecordViewModel> GetMachineDailyRecordReport(DailyRecordSearchModel searchModel);
        List<ActivityNameViewModel> GetActivityNames(Guid salonGuid);
    }
}