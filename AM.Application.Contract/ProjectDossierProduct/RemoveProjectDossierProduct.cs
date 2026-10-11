using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectDossierProduct;

public class RemoveProjectDossierProduct (Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}