using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.Material;

public class MaterialViewModel : ViewModelAbilities
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string UnitName { get; set; }
}
