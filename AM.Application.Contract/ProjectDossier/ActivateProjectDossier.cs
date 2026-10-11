using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossier;

public class ActivateProjectDossier(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
