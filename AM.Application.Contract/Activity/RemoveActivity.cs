using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Activity;

public class RemoveActivity(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}