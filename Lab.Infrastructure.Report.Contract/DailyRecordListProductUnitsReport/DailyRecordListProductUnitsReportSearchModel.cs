namespace Lab.Infrastructure.Report.Contract.DailyRecordListProductUnitsReport
{
    public class DailyRecordListProductUnitsReportSearchModel
    {
        public Guid? SalonGuid { get; set; }
        public List<int>? YearIds { get; set; }
        public List<int>? MonthIds { get; set; }
        public List<int>? WeekIds { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
}
