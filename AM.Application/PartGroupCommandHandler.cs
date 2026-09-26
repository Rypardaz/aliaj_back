using Ex.Application.Contracts.PartGroup;
using Ex.Domain.PartGroupAgg.Service;
using Ex.Domain.PartGroupAgg;
using Ex.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace Ex.Application;

public class PartGroupCommandHandler(
    IClaimHelper claimHelper,
    IPartGroupRepository partGroupRepository,
    IPartGroupService partGroupService,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreatePartGroup, Guid>,
        ICommandHandler<EditPartGroup>,
        ICommandHandler<RemovePartGroup>,
        ICommandHandler<ActivatePartGroup>,
        ICommandHandler<DeactivatePartGroup>
{
    public Guid Handle(CreatePartGroup command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var salonId = salonRepository.GetIdBy(command.SalonGuid);

        var partGroup = new PartGroup(creator, command.Name, salonId, partGroupService);
        partGroupRepository.Create(partGroup);
        return partGroup.Guid;
    }

    public void Handle(EditPartGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var partGroup = partGroupRepository.Load(command.Guid);
        var salonId = salonRepository.GetIdBy(command.SalonGuid);

        partGroup.Edit(actor, command.Name, salonId, partGroupService);
    }

    public void Handle(RemovePartGroup command)
    {
        var partGroup = partGroupRepository.Load(command.Guid);
        partGroupRepository.Delete(partGroup);
    }

    public void Handle(ActivatePartGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var partGroup = partGroupRepository.Load(command.Guid);
        partGroup.Activate();
    }

    public void Handle(DeactivatePartGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var partGroup = partGroupRepository.Load(command.Guid);
        partGroup.Deactivate();
    }
}