using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.PartGroup;

public class DeactivatePartGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}