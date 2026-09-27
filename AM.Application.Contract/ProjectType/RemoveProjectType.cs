using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectType;

public class RemoveProjectType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}