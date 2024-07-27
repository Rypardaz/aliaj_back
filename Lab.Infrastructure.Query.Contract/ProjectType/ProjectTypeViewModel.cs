using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.ProjectType
{
    public class ProjectTypeViewModel : ViewModelAbilities
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string SalonName { get; set; }
        public string IsActiveStr { get; set; }
    }
}
