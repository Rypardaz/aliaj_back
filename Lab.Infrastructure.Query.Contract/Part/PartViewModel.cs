using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.Part
{
    public class PartViewModel : ViewModelAbilities
    {
        public string PartGroupName { get; set; }
        public string Name { get; set; }
        public int StandardWireConsumption { get; set; }
        public string IsActiveStr { get; set; }
    }
}
