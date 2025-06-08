using System;
using System.Collections.Generic;
using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.MachineReport;

public interface IMachineReportService : IReportService
{
    List<ActivityNameViewModel> GetActivityNames(Guid salonGuid);
    List<MachineReportModel> GetMachineReport(MachineReportSearchModel searchModel);
}