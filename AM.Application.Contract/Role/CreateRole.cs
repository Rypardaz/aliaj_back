using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Role;

public class CreateRole : ICommand
{
    public string Title { get; set; }
    public List<int> Permissions { get; set; }
}