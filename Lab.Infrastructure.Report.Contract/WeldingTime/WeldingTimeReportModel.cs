namespace Lab.Infrastructure.Report.Contract.WeldingTime;

public class WeldingTimeReportModel
{
    public string? DateTime { get; set; }
    public string? DayOfWeek { get; set; }
    public string? ShiftWork { get; set; }
    public string? TotalTime { get; set; }
    public string? OnTime_H1 { get; set; }
    public string? WTime_H1 { get; set; }
    public string? AvgVoltage_H1 { get; set; }
    public string? AvgCurrent_H1 { get; set; }
    public string? UpTime_H1 { get; set; }
    public string? Efficiency_H1 { get; set; }
    public string? PowerH1_KWh { get; set; }
    public string? OnTime_H2 { get; set; }
    public string? WTime_H2 { get; set; }
    public string? AvgVoltage_H2 { get; set; }
    public string? AvgCurrent_H2 { get; set; }
    public string? UpTime_H2 { get; set; }
    public string? Efficiency_H2 { get; set; }
    public string? PowerH2_KWh { get; set; }
    public string? TotalPower_KWh { get; set; }
    public string? FirstWeldClock_H1 { get; set; }
    public string? LastWeldClock_H1 { get; set; }
    public string? FirstWeldClock_H2 { get; set; }
    public string? LastWeldClock_H2 { get; set; }
}