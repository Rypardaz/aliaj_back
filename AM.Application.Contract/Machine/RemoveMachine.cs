using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Machine;

public class RemoveMachine(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}