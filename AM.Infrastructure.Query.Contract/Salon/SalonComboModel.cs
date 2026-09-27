using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.Salon;

public class SalonComboModel : ComboBase
{
    public bool HasGas { get; set; }
    public bool HasWire { get; set; }
    public bool HasWireScrew { get; set; }
    public bool HasPowder { get; set; }
}