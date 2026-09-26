using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.WireScrew;

public class ActivateWireScrew(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}