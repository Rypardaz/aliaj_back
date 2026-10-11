using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class DeactivateProjectDossier(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
