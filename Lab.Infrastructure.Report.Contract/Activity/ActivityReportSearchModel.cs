namespace Lab.Infrastructure.Report.Contract.Activity
{
    public class ActivityReportSearchModel
    {
        public Guid SalonGuid { get; set; }
        public int? ActivitySubType { get; set; }
        public Guid? SourceGuid { get; set; }
        public int? WeekId { get; set; }
        public int? MonthId { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }

}
