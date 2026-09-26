using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract.Dashboard;

namespace Lab.Infrastructure.Report;

public class DashboardReportService(BaseDapperRepository dapper) : IDashboardReportService
{
    public List<DashboardViewModel> GetReport(DashboardSearchModel searchModel) =>
        dapper.SelectFromSp<DashboardViewModel>("spDashboard", new
        {
            searchModel.Type,
            searchModel.SalonTypeGuid,
            searchModel.SalonId,
            searchModel.Period
        });
}