using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.Dashboard;

public interface IDashboardReportService : IReportService
{
    List<DashboardViewModel> GetReport(DashboardSearchModel searchModel);
}