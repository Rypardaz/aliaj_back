namespace Lab.Infrastructure.Report.Contract.PersonnelReport
{
    public class PersonnelReportSearchModel
    {
        public Guid PersonnelGuid { get; set; }
        public int? WeekId { get; set; }
        public int? MonthId { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
}
