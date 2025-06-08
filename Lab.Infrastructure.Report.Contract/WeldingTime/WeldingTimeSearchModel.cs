namespace Lab.Infrastructure.Report.Contract.WeldingTime;

public class WeldingTimeSearchModel
{
    public Guid? MachineGuid { get; set; }
    public string? Shift { get; set; }
    public int? MonthId { get; set; }
    public int? YearId { get; set; }
}