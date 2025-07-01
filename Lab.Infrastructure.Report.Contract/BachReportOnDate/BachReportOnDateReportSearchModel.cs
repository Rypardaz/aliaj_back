namespace Lab.Infrastructure.Report.Contract.BachReportOnDate
{
    public class BachReportOnDateReportSearchModel
    {
        public Guid? SalonGuid { get; set; }
        public List<int>? YearIds { get; set; }
        public List<int>? MonthIds { get; set; }
        public List<int>? WeekIds { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? Screw { get; set; }
    }
}
