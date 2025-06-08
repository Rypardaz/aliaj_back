using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract.Dashboard;

namespace Lab.Infrastructure.Report;

public class DashboardReportService : IDashboardReportService
{
    private readonly BaseDapperRepository _dapper;

    public DashboardReportService(BaseDapperRepository dapper)
    {
        _dapper = dapper;
    }

    public List<DashboardViewModel> GetReport(DashboardSearchModel searchModel) =>
        _dapper.SelectFromSp<DashboardViewModel>("spDashboard", new
        {
            searchModel.Type,
            searchModel.SalonTypeGuid,
            searchModel.SalonId,
            searchModel.Period
        });
}