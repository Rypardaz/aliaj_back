using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.Salon
{
    public class SalonComboModel : ComboBase
    {
        public bool HasGas { get; set; }
        public bool HasWire { get; set; }
        public bool HasWireScrew { get; set; }
        public bool HasPowder { get; set; }
    }
}
