using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PowderTypeGroup;

public class ActivatePowderTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}