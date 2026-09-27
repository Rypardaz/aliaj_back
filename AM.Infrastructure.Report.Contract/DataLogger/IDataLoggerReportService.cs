using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.DataLogger;

public interface IDataLoggerReportService : IReportService
{
    List<DataLoggerReportViewModel> GetDataLoggerReport(DataLoggerReportSearchModel searchModel);
}