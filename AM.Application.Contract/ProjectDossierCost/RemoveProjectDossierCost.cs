using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossierCost;

public class RemoveProjectDossierCost(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}