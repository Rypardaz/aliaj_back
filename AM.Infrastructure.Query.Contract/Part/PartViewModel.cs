using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.Part;

public class PartViewModel : ViewModelAbilities
{
    public string PartGroupName { get; set; }
    public string Name { get; set; }
    public decimal? StandardWireConsumption { get; set; }
    public string IsActiveStr { get; set; }
}