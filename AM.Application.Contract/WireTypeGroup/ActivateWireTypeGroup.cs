using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireTypeGroup;

public class ActivateWireTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}