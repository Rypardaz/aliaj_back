using System;
using System.Collections.Generic;

namespace Lab.Infrastructure.Report.Contract.Activity;

public class ActivityReportSearchModel
{
    public Guid SalonGuid { get; set; }
    public int? ActivitySubType { get; set; }
    public Guid? SourceGuid { get; set; }
    public List<int>? WeekIds { get; set; }
    public List<int>? MonthIds { get; set; }
    public List<int>? YearIds { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
}