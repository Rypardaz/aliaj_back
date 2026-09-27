using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.GasTypeGroup;

public class ActivateGasTypeGroup(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}