using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Activity;

public class DeactivateActivity(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}