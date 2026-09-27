using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Project;

public class RemoveProject(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}