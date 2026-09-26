using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PowderTypeGroup;

public class DeactivatePowderTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}