using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.WireType;

public class ActivateWireType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}