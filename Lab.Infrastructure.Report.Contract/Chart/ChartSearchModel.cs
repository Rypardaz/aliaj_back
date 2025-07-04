﻿namespace Lab.Infrastructure.Report.Contract.Chart;

public class ChartSearchModel
{
    public int? Type { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public int? YearIds { get; set; }
    public List<int>? MonthIds { get; set; }
    public List<int>? WeekIds { get; set; }
    public List<Guid>? WireTypeGuid { get; set; }
    public List<Guid>? MachineGuid { get; set; }
    public Guid? SalonGuid { get; set; }
    public List<Guid>? PersonnelGuid { get; set; }
    public Guid? ActivityGuid { get; set; }
    public int? ActivitySubType { get; set; }
    public Guid? ShiftGuid { get; set; }
    public bool ShowShift { get; set; }
}