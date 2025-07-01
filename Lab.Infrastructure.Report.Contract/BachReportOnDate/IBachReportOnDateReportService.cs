using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.BachReportOnDate
{

    public interface IBachReportOnDateReportService : IReportService
    {
        List<BachReportOnDateReportModel> GetBachReportOnDate(BachReportOnDateReportSearchModel searchModel);
    }
}
