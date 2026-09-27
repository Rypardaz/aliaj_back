using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.WireType;

public class RemoveWireType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}