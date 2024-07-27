using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.WireType
{
    public class WireTypeViewModel : ViewModelAbilities
    {
        public string WireTypeGroup { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double? WireSize { get; set; }
        public string IsActiveStr { get; set; }
    }
}
