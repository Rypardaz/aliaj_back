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
        
        string? months = null;
        if (searchModel.MonthIds is not null && searchModel.MonthIds.Count > 0)
        {
            months = string.Join(",", searchModel.MonthIds);
        }

        string? weeks = null;
        if (searchModel.WeekIds is not null && searchModel.WeekIds.Count > 0)
        {
            weeks = string.Join(",", searchModel.WeekIds);
        }

        return _repository.SelectFromSp<ChartViewModel>("spByPartReport", new
        {
            ReportType = 2,
            SalonGuid = salonGuid,
            WeekIds = weeks,
            MonthIds = months,
            searchModel.FromDate,
            searchModel.ToDate
        });
    }

    public List<ChartViewModel> GetWireConsumptionToStandardChart(ChartSearchModel searchModel)
    {
        string? months = null;
        if (searchModel.MonthIds is not null && searchModel.MonthIds.Count > 0)
        {
            months = string.Join(",", searchModel.MonthIds);
        }

        string? weeks = null;
        if (searchModel.WeekIds is not null && searchModel.WeekIds.Count > 0)
        {
            weeks = string.Join(",", searchModel.WeekIds);
        }

        return _repository.SelectFromSp<ChartViewModel>("spByPartReport", new
        {
            ReportType = 3,
            searchModel.SalonGuid,
            WeekIds = weeks,
            MonthIds = months,
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
        string? months = null;
        if (searchModel.MonthIds is not null && searchModel.MonthIds.Count > 0)
        {
            months = string.Join(",", searchModel.MonthIds);
        }
        
        string? weeks = null;
        if (searchModel.WeekIds is not null && searchModel.WeekIds.Count > 0)
        {
            weeks = string.Join(",", searchModel.WeekIds);
        }

        return _repository.SelectFromSp<ChartViewModel>("spActivityReport", new
        {
            ReportType = searchModel.Type,
            searchModel.SalonGuid,
            searchModel.YearIds,
            searchModel.FromDate,
            searchModel.ToDate,
            MonthIds = months,
            WeekIds = weeks,
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

        string? personnel = null;
        if (searchModel.PersonnelGuid is not null && searchModel.PersonnelGuid.Count > 0)
            personnel = string.Join(",", searchModel.PersonnelGuid);


        string? months = null;
        if (searchModel.MonthIds is not null && searchModel.MonthIds.Count > 0)
        {
            months = string.Join(",", searchModel.MonthIds);
        }

        string? weeks = null;
        if (searchModel.WeekIds is not null && searchModel.WeekIds.Count > 0)
        {
            weeks = string.Join(",", searchModel.WeekIds);
        }

        return _repository.SelectFromSp<ChartViewModel>("spWireConsumptionChartReport", new
        {
            searchModel.Type,
            searchModel.FromDate,
            searchModel.ToDate,
            searchModel.YearIds,
            WeekIds = weeks,
            MonthIds = months,
            searchModel.ShiftGuid,
            searchModel.ShowShift,
            WireTypeGuid = wireTypes,
            MachineGuid = machines,
            searchModel.SalonGuid,
            PersonnelGuid = personnel,
        });
    }
}