using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.WeldingTime;

public interface IWeldingTimeReportService : IReportService
{
    List<WeldingTimeReportModel> GetReport(WeldingTimeSearchModel searchModel);
}