using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.Activity;

public class ActivityViewModel : ViewModelAbilities
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string TypeStr { get; set; }
    public string SubTypeStr { get; set; }
    public string IsActiveStr { get; set; }
    public string SourceTitle { get; set; }
    public bool IsOther { get; set; }
    public string WithOutPersonnel { get; set; }
    public string WithOutProject { get; set; }
    public string? Salons { get; set; }
}