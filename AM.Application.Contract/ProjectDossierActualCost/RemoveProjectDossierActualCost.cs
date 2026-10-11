using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossierActualCost;

public class RemoveProjectDossierActualCost(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}