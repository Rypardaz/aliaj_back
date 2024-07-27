using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.Management
{
    public interface IManagementReportService : IReportService
    {
        List<MachineDailyRecordViewModel> GetMachineDailyRecordReport(MachineDailyRecordSearchModel searchModel);
        List<ActivityNameViewModel> GetActivityNames(Guid salonGuid);
    }
}