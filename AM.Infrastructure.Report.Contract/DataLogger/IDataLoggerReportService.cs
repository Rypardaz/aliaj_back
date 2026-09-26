using System.Collections.Generic;
using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.DataLogger;

public interface IDataLoggerReportService : IReportService
{
    List<DataLoggerReportViewModel> GetDataLoggerReport(DataLoggerReportSearchModel searchModel);
}