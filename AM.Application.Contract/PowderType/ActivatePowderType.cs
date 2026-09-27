using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.PowderType;

public class ActivatePowderType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}