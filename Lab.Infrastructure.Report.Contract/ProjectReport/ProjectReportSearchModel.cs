namespace Lab.Infrastructure.Report.Contract.ProjectReport;

public class ProjectReportSearchModel
{
    public Guid ProjectGuid { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public int Type { get; set; }
}