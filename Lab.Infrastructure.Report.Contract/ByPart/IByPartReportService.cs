using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.ByPart
{
    public interface IByPartReportService : IReportService
    {
        List<ByPartReportViewModel> GetByPartReport(ByPartReportSearchModel searchModel);
    }
}
