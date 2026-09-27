using AM.Infrastructure.Report.Contract.Dashboard;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Report;

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