using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Role;

public class DeleteRole(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}