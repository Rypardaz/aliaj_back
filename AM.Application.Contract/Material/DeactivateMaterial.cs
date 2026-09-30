using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Material;

public class DeactivateMaterial(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
