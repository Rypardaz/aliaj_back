using Ex.Application.Contracts.WireType;
using Ex.Domain.WireTypeAgg.Service;
using Ex.Domain.WireTypeAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Domain.WireTypeGroupAgg;
using Ex.Domain.ListItemAgg;

namespace Ex.Application;

public class WireTypeCommandHandler(
    IClaimHelper claimHelper,
    IWireTypeRepository wireTypeRepository,
    IWireTypeService wireTypeService,
    IWireTypeGroupRepository wireTypeGroupRepository,
    IListItemRepository listItemRepository)
    :
        ICommandHandler<CreateWireType, Guid>,
        ICommandHandler<EditWireType>,
        ICommandHandler<RemoveWireType>,
        ICommandHandler<ActivateWireType>,
        ICommandHandler<DeactivateWireType>
{
    private readonly IListItemRepository _listItemRepository = listItemRepository;

    public Guid Handle(CreateWireType command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var wireTypeGroupId = wireTypeGroupRepository.GetIdBy(command.WireTypeGroupGuid);

        //if (_wireTypeRepository.Exists(x => x.Name == command.Name && x.WireTypeGroupId == wireTypeGroupId && x.WireSize == command.WireSize))
        //    throw new BusinessException("0", "اطلاعات وارد شده تکراری است.");

        var wireType = new WireType(creator, wireTypeGroupId, command.Code, command.Name, command.WireSize, wireTypeService);
        wireTypeRepository.Create(wireType);
        return wireType.Guid;
    }

    public void Handle(EditWireType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var wireTypeGroupId = wireTypeGroupRepository.GetIdBy(command.WireTypeGroupGuid);

        //if (_wireTypeRepository.Exists(x => x.Name == command.Name && x.WireTypeGroupId == wireTypeGroupId && x.WireSize == command.WireSize && x.Guid != command.Guid))
        //    throw new BusinessException("0", "اطلاعات وارد شده تکراری است.");

        var wireType = wireTypeRepository.Load(command.Guid);
        wireType.Edit(actor, wireTypeGroupId, command.Code, command.Name, command.WireSize, wireTypeService);
    }

    public void Handle(RemoveWireType command)
    {
        var wireType = wireTypeRepository.Load(command.Guid);
        wireTypeRepository.Delete(wireType);
    }
    public void Handle(ActivateWireType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var wireType = wireTypeRepository.Load(command.Guid);
        wireType.Activate();
    }

    public void Handle(DeactivateWireType command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var wireType = wireTypeRepository.Load(command.Guid);
        wireType.Deactivate();
    }
}