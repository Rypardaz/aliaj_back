namespace AM.Infrastructure.Query.Contract.Project;

public class ProjectSearchModel
{
    public int PeriodId { get; set; }
    public int SearchType { get; set; } // 1, 2, 3
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public bool OnlyActive { get; set; }
}