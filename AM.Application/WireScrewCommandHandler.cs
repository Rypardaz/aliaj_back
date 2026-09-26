using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.WireScrew;
using Ex.Domain.WireScrewAgg.Service;
using Ex.Domain.WireScrewAgg;
using Ex.Domain.WireTypeAgg;

namespace Ex.Application;

public class WireScrewCommandHandler(
    IClaimHelper claimHelper,
    IWireScrewRepository wireScrewRepository,
    IWireScrewService wireScrewService,
    IWireTypeRepository wireTypeRepository)
    :
        ICommandHandler<CreateWireScrew, Guid>,
        ICommandHandler<EditWireScrew>,
        ICommandHandler<RemoveWireScrew>,
        ICommandHandler<ActivateWireScrew>,
        ICommandHandler<DeactivateWireScrew>
{
    public Guid Handle(CreateWireScrew command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var wireTypeId = wireTypeRepository.GetIdBy(command.WireTypeGuid);
        var wireScrew = new WireScrew(creator, wireTypeId, command.Screw, command.Qty, wireScrewService);
        wireScrewRepository.Create(wireScrew);
        return wireScrew.Guid;
    }

    public void Handle(EditWireScrew command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var wireScrew = wireScrewRepository.Load(command.Guid);
        var wireTypeId = wireTypeRepository.GetIdBy(command.WireTypeGuid);
        wireScrew.Edit(actor, wireTypeId, command.Screw, command.Qty, wireScrewService);
    }

    public void Handle(RemoveWireScrew command)
    {
        var wireScrew = wireScrewRepository.Load(command.Guid);
        wireScrewRepository.Delete(wireScrew);
    }
    public void Handle(ActivateWireScrew command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var wireScrew = wireScrewRepository.Load(command.Guid);
        wireScrew.Activate();
    }

    public void Handle(DeactivateWireScrew command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var wireScrew = wireScrewRepository.Load(command.Guid);
        wireScrew.Deactivate();
    }
}