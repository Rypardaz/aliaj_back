using Lab.Infrastructure.Report.Contract.DailyRecordListProductUnitsReport;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report
{
    public class DailyRecordListProductUnitsReportService : IDailyRecordListProductUnitsReportService
    {
        private readonly BaseDapperRepository _dapper;
        public DailyRecordListProductUnitsReportService(BaseDapperRepository dapper)
        {
            _dapper = dapper;
        }

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

           return _dapper.SelectFromSp<DailyRecordListProductUnitsReportModel>("spDailyRecordList_Product_UnitsReport", new
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
}
