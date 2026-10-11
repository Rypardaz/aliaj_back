using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossierCostBeforImplementation;

public class RemoveProjectDossierCostBeforImplementation(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}