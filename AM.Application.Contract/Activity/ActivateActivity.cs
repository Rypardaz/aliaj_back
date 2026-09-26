using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Activity;

public class ActivateActivity(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}