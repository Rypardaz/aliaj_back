namespace Lab.Infrastructure.Report.Contract.DataLogger;

public class DataLoggerReportSearchModel
{
    public string? Shift { get; set; }
    public Guid? MachineGuid { get; set; }
    public string? SpecificDate { get; set; }
}