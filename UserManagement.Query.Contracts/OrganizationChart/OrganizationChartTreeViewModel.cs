using PhoenixFramework.Company.Query;

namespace UserManagement.Query.Contracts.OrganizationChart;

public class OrganizationChartTreeViewModel : ViewModelAbilities
{
    public string? Title { get; set; }
    public long ParentId { get; set; }
}