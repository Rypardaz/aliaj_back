using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Material;

public class RemoveMaterial(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}