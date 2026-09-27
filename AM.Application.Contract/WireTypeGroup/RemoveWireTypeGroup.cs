using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.WireTypeGroup;

public class RemoveWireTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}