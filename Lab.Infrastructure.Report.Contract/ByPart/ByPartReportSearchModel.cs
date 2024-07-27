namespace Lab.Infrastructure.Report.Contract.ByPart
{
    public class ByPartReportSearchModel
    {
        public Guid SalonGuid { get; set; }
        public int? WeekId { get; set; }
        public int? MonthId { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
}
