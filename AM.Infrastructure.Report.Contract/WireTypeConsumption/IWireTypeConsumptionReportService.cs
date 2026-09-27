using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.WireTypeConsumption;

public interface IWireTypeConsumptionReportService : IReportService
{
    List<WireTypeConsumptionReportViewModel> GetWireTypeConsumptionReport(WireTypeConsumptionReportSearchModel searchModel);
}