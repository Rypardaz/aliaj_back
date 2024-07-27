using PhoenixFramework.Company.Query;

namespace UserManagement.Query.Contracts.Company;

public class CompanyViewModel : ViewModelAbilities
{
    public string? Title { get; set; }
    public int ParentId { get; set; }
    public string? ParentTitle { get; set; }
    public string? Address { get; set; }
    public byte[]? Logo { get; set; }
    public string? Description { get; set; }

    public int CountUsed { get; set; }
}