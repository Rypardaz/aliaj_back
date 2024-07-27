using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.Activity
{
    public class ActivityViewModel : ViewModelAbilities
    {
        public string Name { get; set; }
        public string TypeStr { get; set; }
        public string SubTypeStr { get; set; }
        public string IsActiveStr { get; set; }
        public int SourceId { get; set; }
    }
}
