using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class RemoveProjectDossier(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}