using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.ProjectType;

public class DeactivateProjectType(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}