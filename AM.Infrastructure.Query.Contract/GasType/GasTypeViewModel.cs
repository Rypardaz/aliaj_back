using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.GasType;

public class GasTypeViewModel : ViewModelAbilities
{
    public string GasTypeGroup { get; set; }
    public string Name { get; set; }
    public string IsActiveStr { get; set; }
}