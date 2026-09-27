using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Role;

public class DeleteRole(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}