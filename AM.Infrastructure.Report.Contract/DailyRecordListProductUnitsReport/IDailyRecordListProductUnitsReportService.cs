using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.DailyRecordListProductUnitsReport;

public interface IDailyRecordListProductUnitsReportService : IReportService
{
    List<DailyRecordListProductUnitsReportModel> GetDailyRecordListProductUnitsReport(DailyRecordListProductUnitsReportSearchModel searchModel);
}