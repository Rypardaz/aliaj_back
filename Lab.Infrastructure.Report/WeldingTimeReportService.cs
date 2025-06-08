using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract.WeldingTime;

namespace Lab.Infrastructure.Report;

public class WeldingTimeReportService : IWeldingTimeReportService
{
    private readonly BaseDapperRepository _dapper;

    public WeldingTimeReportService(BaseDapperRepository dapper)
    {
        _dapper = dapper;
    }

    public List<WeldingTimeReportModel> GetReport(WeldingTimeSearchModel searchModel) =>
        _dapper.SelectFromSp<WeldingTimeReportModel>("spWeldingTime", new
        {
            searchModel.MachineGuid,
            searchModel.Shift,
            searchModel.MonthId,
            searchModel.YearId
        });
}