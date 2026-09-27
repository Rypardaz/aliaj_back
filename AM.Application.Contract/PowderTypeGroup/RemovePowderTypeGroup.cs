using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.PowderTypeGroup;

public class RemovePowderTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}