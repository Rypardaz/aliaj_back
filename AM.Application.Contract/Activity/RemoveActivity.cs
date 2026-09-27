using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Activity;

public class RemoveActivity(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}