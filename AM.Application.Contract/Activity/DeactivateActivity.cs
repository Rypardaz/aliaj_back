using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Activity;

public class DeactivateActivity(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}