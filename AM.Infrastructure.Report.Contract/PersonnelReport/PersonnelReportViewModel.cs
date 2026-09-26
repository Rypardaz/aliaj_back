namespace Lab.Infrastructure.Report.Contract.PersonnelReport;

public class PersonnelReportViewModel
{
    public string Fullname { get; set; }
    public string NationalCode { get; set; }
    public string? ProjectCode { get; set; }
    public string? TaskMasterName { get; set; }
    public string? PartName { get; set; }
    public string? StandardWireConsumptionPerHours { get; set; }
    public string? TotalHoursReported { get; set; }
    public string? HoursInProduction { get; set; }
    public string? WireConsumption { get; set; }
    public string? StandardWireConsumption { get; set; }
    public string? Randeman { get; set; }
}