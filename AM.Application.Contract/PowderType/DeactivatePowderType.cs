using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PowderType;

public class DeactivatePowderType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}