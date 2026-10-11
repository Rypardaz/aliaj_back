using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossierInvoice;

public class RemoveProjectDossierInvoice(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}