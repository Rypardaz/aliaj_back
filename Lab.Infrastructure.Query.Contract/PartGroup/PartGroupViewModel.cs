using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.PartGroup;

public class PartGroupViewModel : ViewModelAbilities
{
    public string Name { get; set; }
    public string SalonName { get; set; }
    public string IsActiveStr { get; set; }
}