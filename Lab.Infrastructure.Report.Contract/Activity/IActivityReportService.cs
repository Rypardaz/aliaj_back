using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.Activity
{
    public interface IActivityReportService : IReportService
    {
        List<ActivityReportViewModel> GetActivityReport(ActivityReportSearchModel searchModel);
    }

}
