using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.Project;

public class ProjectStepViewModel : ComboBase
{
    public string ItemNo { get; set; }
    public Guid WireTypeGuid { get; set; }
}