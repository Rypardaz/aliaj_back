using Lab.Infrastructure.Report.Contract.WireTypeConsumption;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report;

public class WireTypeConsumptionReportService(BaseDapperRepository repository) : IWireTypeConsumptionReportService
{
    public List<WireTypeConsumptionReportViewModel> GetWireTypeConsumptionReport(WireTypeConsumptionReportSearchModel searchModel)
    {
        string? weekIds = null;
        if (searchModel.WeekIds is not null)
            weekIds = string.Join(",", searchModel.WeekIds);

        string? monthIds = null;
        if (searchModel.MonthIds is not null)
            monthIds = string.Join(",", searchModel.MonthIds);

        string? yearIds = null;
        if (searchModel.YearIds is not null)
            yearIds = string.Join(",", searchModel.YearIds);

        return repository.SelectFromSp<WireTypeConsumptionReportViewModel>("spWireTypeConsumptionReport", new
        {
            searchModel.Type,
            searchModel.SalonGuid,
            searchModel.ShiftGuid,
            WeekIds = weekIds,
            MonthIds = monthIds,
            YearIds = yearIds,
            searchModel.FromDate,
            searchModel.ToDate
        });
    }
}