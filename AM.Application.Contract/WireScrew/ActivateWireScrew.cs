using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.WireScrew;

public class ActivateWireScrew(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}