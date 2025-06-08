using Lab.Infrastructure.Report.Contract;
using Lab.Infrastructure.Report.Contract.Activity;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report;

public class ActivityReportService : IActivityReportService
{
    private readonly BaseDapperRepository _repository;

    public ActivityReportService(BaseDapperRepository repository)
    {
        _repository = repository;
    }

    public List<ActivityNameViewModel> GetActivityNames(Guid salonGuid)
    {
        return _repository.SelectFromSp<ActivityNameViewModel>("spActivityReport", new
        {
            ReportType = 0,
            SalonGuid = salonGuid
        });
    }

    public List<ActivityReportViewModel> GetActivityReport(ActivityReportSearchModel searchModel)
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

        return _repository.SelectFromSp<ActivityReportViewModel>("spActivityReport", new
        {
            ReportType = 1,
            searchModel.SalonGuid,
            searchModel.ActivitySubType,
            searchModel.SourceGuid,
            WeekIds = weekIds,
            MonthIds = monthIds,
            YearIds = yearIds,
            searchModel.FromDate,
            searchModel.ToDate
        });
    }
}