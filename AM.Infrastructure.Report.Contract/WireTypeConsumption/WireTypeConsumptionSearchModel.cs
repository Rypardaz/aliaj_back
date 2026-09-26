namespace Lab.Infrastructure.Report.Contract.WireTypeConsumption;

public class WireTypeConsumptionReportSearchModel
{
    public Guid SalonGuid { get; set; }
    public Guid? ShiftGuid { get; set; }
    public List<int>? WeekIds { get; set; }
    public List<int>? MonthIds { get; set; }
    public List<int>? YearIds { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public int Type { get; set; }
}