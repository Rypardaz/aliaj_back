using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.GasType;

public class RemoveGasType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}