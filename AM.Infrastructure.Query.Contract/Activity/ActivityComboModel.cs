using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.Activity;

public class ActivityComboModel : ComboBase
{
    public int Type { get; set; }
    public int SubType { get; set; }
    public string Code { get; set; }
}