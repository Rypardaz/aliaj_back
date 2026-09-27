using PhoenixFramework.Company.Query;

namespace AM.Application.Contracts.Role;

public class RoleViewModel : ViewModelAbilities
{
    public string Title { get; set; }
    public int UserCount { get; set; }
}