using System.Collections.Generic;
using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.WeldingTime;

public interface IWeldingTimeReportService : IReportService
{
    List<WeldingTimeReportModel> GetReport(WeldingTimeSearchModel searchModel);
}