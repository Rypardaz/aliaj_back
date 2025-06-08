using Lab.Infrastructure.Report.Contract.DailyRecordListReport;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report
{
    public class DailyRecordListReportService : IDailyRecordListReportService
    {
        private readonly BaseDapperRepository _dapper;

        public DailyRecordListReportService(BaseDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public List<DailyRecordListReportModel> GetDailyRecordListReport(DailyRecordListReportSearchModel searchModel)
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

            return _dapper.SelectFromSp<DailyRecordListReportModel>("spDailyRecordListReport", new
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
