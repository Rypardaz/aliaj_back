using AM.Infrastructure.Report.Contract.DataLogger;
using PhoenixFramework.Application;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Report;

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