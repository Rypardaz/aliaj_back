using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.Project;

public class ProjectStepViewModel : ComboBase
{
    public string ItemNo { get; set; }
    public Guid WireTypeGuid { get; set; }
}