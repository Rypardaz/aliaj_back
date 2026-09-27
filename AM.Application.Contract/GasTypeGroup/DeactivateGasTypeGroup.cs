using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.GasTypeGroup;

public class DeactivateGasTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}