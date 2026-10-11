using AM.Application.Contracts.ProjectDossierProduct;
using AM.Domain.ListItemAgg;
using AM.Domain.ProjectDossierProductAgg;
using AM.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Application;

public class ProjectDossierProductCommandHandler(
    IClaimHelper claimHelper,
    IProjectDossierProductRepository projectDossierProductRepository,
    IListItemRepository listItemRepository,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreateProjectDossierProduct, Guid>,
        ICommandHandler<EditProjectDossierProduct>,
        ICommandHandler<RemoveProjectDossierProduct>
{
    public Guid Handle(CreateProjectDossierProduct command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var projectDossierProduct = new ProjectDossierProduct(creator, command.ProjectDossierId, command.ItemNo, command.ProductCode, command.ProductName, command.Unit, command.Fee, command.Qty, command.Amount, command.BuyState, command.BuyDate, command.EstimatedShippingDate, command.LastState);
        projectDossierProductRepository.Create(projectDossierProduct);

        return projectDossierProduct.Guid;
    }

    public void Handle(EditProjectDossierProduct command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var projectDossierProduct = projectDossierProductRepository.Load(command.Guid);

        projectDossierProduct.Edit(actor, command.ProjectDossierId, command.ItemNo, command.ProductCode, command.ProductName, command.Unit, command.Fee, command.Qty, command.Amount, command.BuyState, command.BuyDate, command.EstimatedShippingDate, command.LastState);
    }

    public void Handle(RemoveProjectDossierProduct command)
    {
        var projectDossierProduct = projectDossierProductRepository.Load(command.Guid);
        projectDossierProductRepository.Delete(projectDossierProduct);
    }
}