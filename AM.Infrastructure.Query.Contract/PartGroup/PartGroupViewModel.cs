using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.PartGroup;

public class PartGroupViewModel : ViewModelAbilities
{
    public string Name { get; set; }
    public string SalonName { get; set; }
    public string IsActiveStr { get; set; }
}