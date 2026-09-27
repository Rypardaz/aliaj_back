using AM.Application.Contracts.WireTypeGroup;
using AM.Domain.WireTypeGroupAgg;
using AM.Domain.WireTypeGroupAgg.Service;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class WireTypeGroupCommandHandler(
    IClaimHelper claimHelper,
    IWireTypeGroupRepository wireTypeGroupRepository,
    IWireTypeGroupService wireTypeGroupService)
    :
        ICommandHandler<CreateWireTypeGroup, Guid>,
        ICommandHandler<EditWireTypeGroup>,
        ICommandHandler<RemoveWireTypeGroup>,
        ICommandHandler<ActivateWireTypeGroup>,
        ICommandHandler<DeactivateWireTypeGroup>
{
    public Guid Handle(CreateWireTypeGroup command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var wireTypeGroup = new WireTypeGroup(creator, command.Name, wireTypeGroupService);
        wireTypeGroupRepository.Create(wireTypeGroup);
        return wireTypeGroup.Guid;
    }

    public void Handle(EditWireTypeGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var wireTypeGroup = wireTypeGroupRepository.Load(command.Guid);
        wireTypeGroup.Edit(actor, command.Name, wireTypeGroupService);
    }

    public void Handle(RemoveWireTypeGroup command)
    {
        var wireTypeGroup = wireTypeGroupRepository.Load(command.Guid);
        wireTypeGroupRepository.Delete(wireTypeGroup);
    }
    public void Handle(ActivateWireTypeGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var wireTypeGroup = wireTypeGroupRepository.Load(command.Guid);
        wireTypeGroup.Activate();
    }

    public void Handle(DeactivateWireTypeGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var wireTypeGroup = wireTypeGroupRepository.Load(command.Guid);
        wireTypeGroup.Deactivate();
    }
}