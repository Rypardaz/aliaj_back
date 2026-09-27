using AM.Infrastructure.Report.Contract.WeldingTime;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Report;

public class WeldingTimeReportService(BaseDapperRepository dapper) : IWeldingTimeReportService
{
    public List<WeldingTimeReportModel> GetReport(WeldingTimeSearchModel searchModel) =>
        dapper.SelectFromSp<WeldingTimeReportModel>("spWeldingTime", new
        {
            searchModel.MachineGuid,
            searchModel.Shift,
            searchModel.MonthId,
            searchModel.YearId
        });
}