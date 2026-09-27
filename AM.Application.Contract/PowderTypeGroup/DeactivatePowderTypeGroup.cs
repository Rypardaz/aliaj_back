using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.PowderTypeGroup;

public class DeactivatePowderTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}