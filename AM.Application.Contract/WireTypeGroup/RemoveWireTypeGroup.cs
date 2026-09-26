using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireTypeGroup;

public class RemoveWireTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}