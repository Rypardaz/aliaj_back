using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Material;

public class ActivateMaterial(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
