using Ex.Application.Contracts.GasType;
using Ex.Domain.GasTypeAgg.Service;
using Ex.Domain.GasTypeAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Domain.GasTypeGroupAgg;

namespace Ex.Application;

public class GasTypeCommandHandler(
    IClaimHelper claimHelper,
    IGasTypeRepository gasTypeRepository,
    IGasTypeService gasTypeService,
    IGasTypeGroupRepository gasTypeGroupRepository)
    :
        ICommandHandler<CreateGasType, Guid>,
        ICommandHandler<EditGasType>,
        ICommandHandler<RemoveGasType>,
        ICommandHandler<ActivateGasType>,
        ICommandHandler<DeactivateGasType>
{
    public Guid Handle(CreateGasType command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var gasTypeGroupId = gasTypeGroupRepository.GetIdBy(command.GasTypeGroupGuid);
        var gasType = new GasType(creator, gasTypeGroupId, command.Name, gasTypeService);
        gasTypeRepository.Create(gasType);
        return gasType.Guid;
    }

    public void Handle(EditGasType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var gasType = gasTypeRepository.Load(command.Guid);
        var gasTypeGroupId = gasTypeGroupRepository.GetIdBy(command.GasTypeGroupGuid);
        gasType.Edit(actor, gasTypeGroupId, command.Name, gasTypeService);
    }

    public void Handle(RemoveGasType command)
    {
        var gasType = gasTypeRepository.Load(command.Guid);
        gasTypeRepository.Delete(gasType);
    }
    public void Handle(ActivateGasType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var gasType = gasTypeRepository.Load(command.Guid);
        gasType.Activate();
    }

    public void Handle(DeactivateGasType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var gasType = gasTypeRepository.Load(command.Guid);
        gasType.Deactivate();
    }
}