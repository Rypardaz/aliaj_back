using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.WireTypeGroup;

public class ActivateWireTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}