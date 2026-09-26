using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.GasTypeGroup;

public class RemoveGasTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}