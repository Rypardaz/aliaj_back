using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.Machine
{
    public class MachineViewModel : ViewModelAbilities
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Salon { get; set; }
        public byte HeadCount { get; set; }
        public string Description { get; set; }
        public string IsActiveStr { get; set; }
    }
}
