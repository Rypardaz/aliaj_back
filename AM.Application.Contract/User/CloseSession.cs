using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.User;

public class CloseSession(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}