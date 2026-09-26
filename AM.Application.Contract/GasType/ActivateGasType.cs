using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.GasType;

public class ActivateGasType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}