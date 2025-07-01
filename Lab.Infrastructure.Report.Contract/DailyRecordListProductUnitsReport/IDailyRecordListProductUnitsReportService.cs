using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.DailyRecordListProductUnitsReport
{
    public interface IDailyRecordListProductUnitsReportService : IReportService
    {
        List<DailyRecordListProductUnitsReportModel> GetDailyRecordListProductUnitsReport(DailyRecordListProductUnitsReportSearchModel searchModel);
    }
}
