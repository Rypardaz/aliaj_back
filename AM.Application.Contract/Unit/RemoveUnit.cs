
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Unit;

public class RemoveUnit(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}