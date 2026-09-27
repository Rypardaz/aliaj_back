using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.User;

public class CloseSession(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}