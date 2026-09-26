using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Project;

public class RemoveProject(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}