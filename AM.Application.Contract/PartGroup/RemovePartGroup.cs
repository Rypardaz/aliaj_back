using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PartGroup;

public class RemovePartGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}