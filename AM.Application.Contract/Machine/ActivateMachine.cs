using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Machine;

public class ActivateMachine(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}