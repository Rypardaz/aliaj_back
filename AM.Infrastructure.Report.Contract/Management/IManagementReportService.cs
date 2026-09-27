using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.Management;

public interface IManagementReportService : IReportService
{
    List<DailyRecordViewModel> GetMachineDailyRecordReport(DailyRecordSearchModel searchModel);
    List<ActivityNameViewModel> GetActivityNames(Guid salonGuid);
}