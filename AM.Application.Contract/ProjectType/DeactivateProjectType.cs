using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectType;

public class DeactivateProjectType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}