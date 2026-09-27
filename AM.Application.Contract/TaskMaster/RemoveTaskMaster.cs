using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.TaskMaster;

public class RemoveTaskMaster(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}