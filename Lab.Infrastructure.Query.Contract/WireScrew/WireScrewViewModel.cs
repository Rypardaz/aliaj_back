using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.WireScrew
{
    public class WireScrewViewModel : ViewModelAbilities
    {
        public string WireType { get; set; }
        public string Screw { get; set; }
        public string WireSize { get; set; }
        public decimal Qty { get; set; }
        public string IsActiveStr { get; set; }
    }
}
