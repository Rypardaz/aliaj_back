using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Salon;
using Ex.Domain.SalonAgg.Service;
using Ex.Domain.SalonAgg;
using Ex.Domain.ListItemAgg;

namespace Ex.Application;

public class SalonCommandHandler(
    IClaimHelper claimHelper,
    ISalonRepository salonRepository,
    ISalonService salonService,
    IListItemRepository listItemRepository)
    :
        ICommandHandler<CreateSalon, Guid>,
        ICommandHandler<EditSalon>,
        ICommandHandler<RemoveSalon>,
        ICommandHandler<ActivateSalon>,
        ICommandHandler<DeactivateSalon>
{
    public Guid Handle(CreateSalon command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var type = listItemRepository.GetIdBy(command.TypeGuid);

        var salon = new Salon(creator, command.Name, command.Code, type, command.HasGas, command.HasWire, command.HasWireScrew,
            command.HasPowder, salonService);
            
        salonRepository.Create(salon);
        return salon.Guid;
    }

    public void Handle(EditSalon command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var salon = salonRepository.Load(command.Guid);
        var type = listItemRepository.GetIdBy(command.TypeGuid);

        salon.Edit(actor, command.Name, command.Code, type, command.HasGas, command.HasWire, command.HasWireScrew,
            command.HasPowder, salonService);
    }

    public void Handle(RemoveSalon command)
    {
        var salon = salonRepository.Load(command.Guid);
        salonRepository.Delete(salon);
    }
    public void Handle(ActivateSalon command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var salon = salonRepository.Load(command.Guid);
        salon.Activate();
    }

    public void Handle(DeactivateSalon command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var salon = salonRepository.Load(command.Guid);
        salon.Deactivate();
    }
}