using System.Collections.Generic;
using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.Dashboard;

public interface IDashboardReportService : IReportService
{
    List<DashboardViewModel> GetReport(DashboardSearchModel searchModel);
}