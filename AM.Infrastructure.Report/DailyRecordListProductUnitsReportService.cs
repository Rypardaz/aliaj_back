using AM.Infrastructure.Report.Contract.DailyRecordListProductUnitsReport;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Report;

public class DailyRecordListProductUnitsReportService(BaseDapperRepository dapper)
    : IDailyRecordListProductUnitsReportService
{
    public List<DailyRecordListProductUnitsReportModel> GetDailyRecordListProductUnitsReport(DailyRecordListProductUnitsReportSearchModel searchModel)
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

        return dapper.SelectFromSp<DailyRecordListProductUnitsReportModel>("spDailyRecordList_Product_UnitsReport", new
        {
            searchModel.SalonGuid,
            YearIds = yearIds,
            MonthIds = monthIds,
            WeekIds = weekIds,
            searchModel.FromDate,
            searchModel.ToDate
        });
    }
}