using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.ByPart;

public interface IByPartReportService : IReportService
{
    List<ByPartReportViewModel> GetByPartReport(ByPartReportSearchModel searchModel);
}