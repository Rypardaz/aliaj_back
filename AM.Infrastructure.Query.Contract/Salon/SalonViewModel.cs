using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.Salon;

public class SalonViewModel : ViewModelAbilities
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string TypeName { get; set; }
    public string HasGas { get; set; }
    public string HasWire { get; set; }
    public string HasWireScrew { get; set; }
    public string HasPowder { get; set; }
    public string SalonName { get; set; }
    public string IsActiveStr { get; set; }
}