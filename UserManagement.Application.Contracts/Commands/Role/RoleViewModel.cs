using PhoenixFramework.Company.Query;

namespace UserManagement.Application.Contracts.Commands.Role;

public class RoleViewModel : ViewModelAbilities
{
    public string Title { get; set; }
    public int UserCount { get; set; }
}