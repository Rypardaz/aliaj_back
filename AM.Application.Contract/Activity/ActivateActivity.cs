using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Activity;

public class ActivateActivity(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}