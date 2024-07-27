using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.Activity
{
    public class ActivityComboModel : ComboBase
    {
        public int Type { get; set; }
        public int SubType { get; set; }
    }
}