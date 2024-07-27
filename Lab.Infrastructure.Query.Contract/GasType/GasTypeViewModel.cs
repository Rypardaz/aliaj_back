using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.GasType
{
    public class GasTypeViewModel : ViewModelAbilities
    {
        public string GasTypeGroup { get; set; }
        public string Name { get; set; }
        public string IsActiveStr { get; set; }
    }
}
