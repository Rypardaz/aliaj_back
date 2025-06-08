using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract;
using Lab.Infrastructure.Report.Contract.Management;

namespace Lab.Infrastructure.Report;

public class DailyReportService : IManagementReportService
{
    private readonly BaseDapperRepository _repository;

    public DailyReportService(BaseDapperRepository repository)
    {
        _repository = repository;
    }

    public List<ActivityNameViewModel> GetActivityNames(Guid salonGuid)
    {
        return _repository.SelectFromSp<ActivityNameViewModel>("spDailyReport", new
        {
            Type = 0,
            SalonGuid = salonGuid
        });
    }

    public List<DailyRecordViewModel> GetMachineDailyRecordReport(DailyRecordSearchModel searchModel)
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

        return _repository.SelectFromSp<DailyRecordViewModel>("spDailyReport", new
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