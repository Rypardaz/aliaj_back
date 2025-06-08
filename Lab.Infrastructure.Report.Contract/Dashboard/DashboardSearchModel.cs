using System;

namespace Lab.Infrastructure.Report.Contract.Dashboard;

public class DashboardSearchModel
{
    public int Type { get; set; }
    public int SalonId { get; set; }
    public Guid? SalonTypeGuid { get; set; }
    public int? Period { get; set; }
}