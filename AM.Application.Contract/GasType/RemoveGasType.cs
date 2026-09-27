using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.GasType;

public class RemoveGasType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}