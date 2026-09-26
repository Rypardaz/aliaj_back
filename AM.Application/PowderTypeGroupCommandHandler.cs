using Ex.Application.Contracts.PowderTypeGroup;
using Ex.Domain.PowderTypeGroupAgg.Service;
using Ex.Domain.PowderTypeGroupAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace Ex.Application;

public class PowderTypeGroupCommandHandler(
    IClaimHelper claimHelper,
    IPowderTypeGroupRepository powderTypeGroupRepository,
    IPowderTypeGroupService powderTypeGroupService)
    :
        ICommandHandler<CreatePowderTypeGroup, Guid>,
        ICommandHandler<EditPowderTypeGroup>,
        ICommandHandler<RemovePowderTypeGroup>,
        ICommandHandler<ActivatePowderTypeGroup>,
        ICommandHandler<DeactivatePowderTypeGroup>
{
    public Guid Handle(CreatePowderTypeGroup command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var powderTypeGroup = new PowderTypeGroup(creator, command.Name, powderTypeGroupService);
        powderTypeGroupRepository.Create(powderTypeGroup);
        return powderTypeGroup.Guid;
    }

    public void Handle(EditPowderTypeGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var powderTypeGroup = powderTypeGroupRepository.Load(command.Guid);
        powderTypeGroup.Edit(actor, command.Name, powderTypeGroupService);
    }

    public void Handle(RemovePowderTypeGroup command)
    {
        var powderTypeGroup = powderTypeGroupRepository.Load(command.Guid);
        powderTypeGroupRepository.Delete(powderTypeGroup);
    }
    public void Handle(ActivatePowderTypeGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var powderTypeGroup = powderTypeGroupRepository.Load(command.Guid);
        powderTypeGroup.Activate();
    }

    public void Handle(DeactivatePowderTypeGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var powderTypeGroup = powderTypeGroupRepository.Load(command.Guid);
        powderTypeGroup.Deactivate();
    }
}