using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.BachReportOnDate;

public interface IBachReportOnDateReportService : IReportService
{
    List<BachReportOnDateReportModel> GetBachReportOnDate(BachReportOnDateReportSearchModel searchModel);
}