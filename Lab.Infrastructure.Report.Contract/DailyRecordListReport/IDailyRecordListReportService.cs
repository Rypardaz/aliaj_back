using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.DailyRecordListReport
{
    public interface IDailyRecordListReportService : IReportService
    {
        List<DailyRecordListReportModel> GetDailyRecordListReport(DailyRecordListReportSearchModel searchModel);
    }
}
