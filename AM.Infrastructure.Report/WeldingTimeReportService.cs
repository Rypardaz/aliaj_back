using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract.WeldingTime;

namespace Lab.Infrastructure.Report;

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