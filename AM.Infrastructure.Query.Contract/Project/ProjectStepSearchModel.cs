namespace Lab.Infrastructure.Query.Contracts.Project;

public class ProjectStepSearchModel
{
    public Guid ProjectGuid { get; set; }
    public Guid? PartGuid { get; set; }
    public string? partCode { get; set; }

}