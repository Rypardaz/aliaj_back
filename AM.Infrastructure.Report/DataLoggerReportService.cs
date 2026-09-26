using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract.DataLogger;
using PhoenixFramework.Application;

namespace Lab.Infrastructure.Report;

public class DataLoggerReportService(BaseDapperRepository repository) : IDataLoggerReportService
{
    public List<DataLoggerReportViewModel> GetDataLoggerReport(DataLoggerReportSearchModel searchModel)
    {
        DateTime? specifiedDate = null;
        if (!string.IsNullOrWhiteSpace(searchModel.SpecificDate))
            specifiedDate = searchModel.SpecificDate.ToGeorgianDateTime();

        return repository.SelectFromSp<DataLoggerReportViewModel>("spDataLogger",
            new
            {
                searchModel.MachineGuid,
                searchModel.Shift,
                SpecificDate = specifiedDate
            });
    }
}