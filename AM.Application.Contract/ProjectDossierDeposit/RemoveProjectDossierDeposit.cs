using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossierDeposit;

public class RemoveProjectDossierDeposit(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}