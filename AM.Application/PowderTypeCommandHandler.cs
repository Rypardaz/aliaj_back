using AM.Application.Contracts.PowderType;
using AM.Domain.PowderTypeAgg;
using AM.Domain.PowderTypeAgg.Service;
using AM.Domain.PowderTypeGroupAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class PowderTypeCommandHandler(
    IClaimHelper claimHelper,
    IPowderTypeRepository powderTypeRepository,
    IPowderTypeService powderTypeService,
    IPowderTypeGroupRepository powderTypeGroupRepository)
    :
        ICommandHandler<CreatePowderType, Guid>,
        ICommandHandler<EditPowderType>,
        ICommandHandler<RemovePowderType>,
        ICommandHandler<ActivatePowderType>,
        ICommandHandler<DeactivatePowderType>
{
    public Guid Handle(CreatePowderType command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var powderTypeGroupId = powderTypeGroupRepository.GetIdBy(command.PowderTypeGroupGuid);
        var powderType = new PowderType(creator, powderTypeGroupId, command.Name, powderTypeService);
        powderTypeRepository.Create(powderType);
        return powderType.Guid;
    }

    public void Handle(EditPowderType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var powderType = powderTypeRepository.Load(command.Guid);
        var powderTypeGroupId = powderTypeGroupRepository.GetIdBy(command.PowderTypeGroupGuid);
        powderType.Edit(actor, powderTypeGroupId, command.Name, powderTypeService);
    }

    public void Handle(RemovePowderType command)
    {
        var powderType = powderTypeRepository.Load(command.Guid);
        powderTypeRepository.Delete(powderType);
    }
    public void Handle(ActivatePowderType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var powderType = powderTypeRepository.Load(command.Guid);
        powderType.Activate();
    }

    public void Handle(DeactivatePowderType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var powderType = powderTypeRepository.Load(command.Guid);
        powderType.Deactivate();
    }
}