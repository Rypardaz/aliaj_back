using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.WireScrew;

public class DeactivateWireScrew(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}