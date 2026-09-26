using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireType;

public class ActivateWireType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}