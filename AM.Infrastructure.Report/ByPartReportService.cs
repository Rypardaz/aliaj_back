using Lab.Infrastructure.Report.Contract.ByPart;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report;

public class ByPartReportService(BaseDapperRepository repository) : IByPartReportService
{
    public List<ByPartReportViewModel> GetByPartReport(ByPartReportSearchModel searchModel)
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

        return repository.SelectFromSp<ByPartReportViewModel>("spByPartReport", new
        {
            searchModel.SalonGuid,
            WeekIds = weekIds,
            MonthIds = monthIds,
            YearIds = yearIds, 
            searchModel.FromDate,
            searchModel.ToDate
        });
    }
}