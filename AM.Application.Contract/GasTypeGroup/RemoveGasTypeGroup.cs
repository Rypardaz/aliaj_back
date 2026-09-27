using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.GasTypeGroup;

public class RemoveGasTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}