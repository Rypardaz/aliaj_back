using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.GasTypeGroup;

public class DeactivateGasTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}