using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.WireTypeConsumption
{
    public interface IWireTypeConsumptionReportService : IReportService
    {
        List<WireTypeConsumptionReportViewModel> GetWireTypeConsumptionReport(WireTypeConsumptionReportSearchModel searchModel);
    }
}
