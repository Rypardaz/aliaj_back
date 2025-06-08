using Lab.Infrastructure.Report.Contract.WireTypeConsumption;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report;

public class WireTypeConsumptionReportService : IWireTypeConsumptionReportService
{
    private readonly BaseDapperRepository _repository;

    public WireTypeConsumptionReportService(BaseDapperRepository repository)
    {
        _repository = repository;
    }

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

        return _repository.SelectFromSp<WireTypeConsumptionReportViewModel>("spWireTypeConsumptionReport", new
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