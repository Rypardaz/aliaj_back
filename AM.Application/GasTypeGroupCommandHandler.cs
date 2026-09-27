using AM.Application.Contracts.GasTypeGroup;
using AM.Domain.GasTypeGroupAgg;
using AM.Domain.GasTypeGroupAgg.Service;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class GasTypeGroupCommandHandler(
    IClaimHelper claimHelper,
    IGasTypeGroupRepository gasTypeGroupRepository,
    IGasTypeGroupService gasTypeGroupService)
    :
        ICommandHandler<CreateGasTypeGroup, Guid>,
        ICommandHandler<EditGasTypeGroup>,
        ICommandHandler<RemoveGasTypeGroup>,
        ICommandHandler<ActivateGasTypeGroup>,
        ICommandHandler<DeactivateGasTypeGroup>
{
    public Guid Handle(CreateGasTypeGroup command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var gasTypeGroup = new GasTypeGroup(creator, command.Name, gasTypeGroupService);
        gasTypeGroupRepository.Create(gasTypeGroup);
        return gasTypeGroup.Guid;
    }

    public void Handle(EditGasTypeGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var gasTypeGroup = gasTypeGroupRepository.Load(command.Guid);
        gasTypeGroup.Edit(actor, command.Name, gasTypeGroupService);
    }

    public void Handle(RemoveGasTypeGroup command)
    {
        var gasTypeGroup = gasTypeGroupRepository.Load(command.Guid);
        gasTypeGroupRepository.Delete(gasTypeGroup);
    }
    public void Handle(ActivateGasTypeGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var gasTypeGroup = gasTypeGroupRepository.Load(command.Guid);
        gasTypeGroup.Activate();
    }

    public void Handle(DeactivateGasTypeGroup command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var gasTypeGroup = gasTypeGroupRepository.Load(command.Guid);
        gasTypeGroup.Deactivate();
    }
}