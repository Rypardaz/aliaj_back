using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.DailyRecordListReport;

public interface IDailyRecordListReportService : IReportService
{
    List<DailyRecordListReportModel> GetDailyRecordListReport(DailyRecordListReportSearchModel searchModel);
}