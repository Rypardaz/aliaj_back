using PhoenixFramework.Core;
using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract.Chart;

namespace Lab.Infrastructure.Report;

public class ChartReportService : IChartReportService
{
    private readonly BaseDapperRepository _repository;

    public ChartReportService(BaseDapperRepository repository)
    {
        _repository = repository;
    }

    public List<ChartViewModel> GetRandemanChart(ChartSearchModel searchModel)
    {
        var salonGuid = string.Join(",", searchModel.SalonGuid);

        return _repository.SelectFromSp<ChartViewModel>("spByPartReport", new
        {
            ReportType = 2,
            SalonGuid = salonGuid,
            searchModel.WeekId,
            searchModel.MonthId,
            searchModel.FromDate,
            searchModel.ToDate
        });
    }

    public List<ChartViewModel> GetWireConsumptionToStandardChart(ChartSearchModel searchModel)
    {
        var salonGuid = string.Join(",", searchModel.SalonGuid);

        return _repository.SelectFromSp<ChartViewModel>("spByPartReport", new
        {
            ReportType = 3,
            SalonGuid = salonGuid,
            searchModel.WeekId,
            searchModel.MonthId,
            searchModel.FromDate,
            searchModel.ToDate
        });
    }

    public List<ChartViewModel> GetProjectChart(ChartSearchModel searchModel)
    {
        return _repository.SelectFromSp<ChartViewModel>("spProjectReport", new
        {
            ReportType = 2,
            searchModel.FromDate,
            searchModel.ToDate
        });
    }

    public List<ChartViewModel> GetActivityChart(ChartSearchModel searchModel)
    {
        return _repository.SelectFromSp<ChartViewModel>("spActivityReport", new
        {
            ReportType = searchModel.Type,
            searchModel.FromDate,
            searchModel.ToDate,
            searchModel.ActivityGuid,
            searchModel.ActivitySubType
        });
    }

    public List<ChartViewModel> GetWireConsumptionChart(ChartSearchModel searchModel)
    {
        string? wireTypes = null;
        if (searchModel.WireTypeGuid is not null && searchModel.WireTypeGuid.Count > 0)
            wireTypes = string.Join(",", searchModel.WireTypeGuid);

        string? machines = null;
        if (searchModel.MachineGuid is not null && searchModel.MachineGuid.Count > 0)
            machines = string.Join(",", searchModel.MachineGuid);

        string? salons = null;
        if (searchModel.SalonGuid is not null && searchModel.SalonGuid.Count > 0)
            salons = string.Join(",", searchModel.SalonGuid);

        string? personnel = null;
        if (searchModel.PersonnelGuid is not null && searchModel.PersonnelGuid.Count > 0)
            personnel = string.Join(",", searchModel.PersonnelGuid);

        return _repository.SelectFromSp<ChartViewModel>("spWireConsumptionChartReport", new
        {
            searchModel.Type,
            searchModel.FromDate,
            searchModel.ToDate,
            searchModel.YearIds,
            searchModel.WeekId,
            searchModel.MonthId,
            searchModel.ShiftGuid,
            searchModel.ShowShift,
            WireTypeGuid = wireTypes,
            MachineGuid = machines,
            SalonGuid = salons,
            PersonnelGuid = personnel,
        });
    }
}