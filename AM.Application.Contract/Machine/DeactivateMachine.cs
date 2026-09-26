using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Machine;

public class DeactivateMachine(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}