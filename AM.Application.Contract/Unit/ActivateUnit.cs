
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Unit;

public class ActivateUnit(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
