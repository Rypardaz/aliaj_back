using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.TaskMaster;

public class ActivateTaskMaster(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}