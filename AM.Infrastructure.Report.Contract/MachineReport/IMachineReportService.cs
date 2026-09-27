using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.MachineReport;

public interface IMachineReportService : IReportService
{
    List<ActivityNameViewModel> GetActivityNames(Guid salonGuid);
    List<MachineReportModel> GetMachineReport(MachineReportSearchModel searchModel);
}