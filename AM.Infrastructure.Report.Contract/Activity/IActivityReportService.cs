using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.Activity;

public interface IActivityReportService : IReportService
{
    List<ActivityNameViewModel> GetActivityNames(Guid salonGuid);
    List<ActivityReportViewModel> GetActivityReport(ActivityReportSearchModel searchModel);
}