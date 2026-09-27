using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Machine;

public class RemoveMachine(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}