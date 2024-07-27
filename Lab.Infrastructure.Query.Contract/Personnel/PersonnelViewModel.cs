using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.Personnel
{
    public class PersonnelViewModel : ViewModelAbilities
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string SalonName { get; set; }
        public string IsActiveStr { get; set; }
    }
}
