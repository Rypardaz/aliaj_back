using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.PowderType;

public class PowderTypeViewModel : ViewModelAbilities
{
    public string PowderTypeGroup { get; set; }
    public string Name { get; set; }
    public string IsActiveStr { get; set; }
}