using Ex.Application.Contracts.WireType;
using Ex.Domain.WireTypeAgg.Service;
using Ex.Domain.WireTypeAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Domain.WireTypeGroupAgg;
using Ex.Domain.ListItemAgg;

namespace Ex.Application
{
    public class WireTypeCommandHandler :
    ICommandHandler<CreateWireType, Guid>,
    ICommandHandler<EditWireType>,
    ICommandHandler<RemoveWireType>,
    ICommandHandler<ActivateWireType>,
    ICommandHandler<DeactivateWireType>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IWireTypeRepository _wireTypeRepository;
        private readonly IWireTypeService _wireTypeService;
        private readonly IWireTypeGroupRepository _wireTypeGroupRepository;
        private readonly IListItemRepository _listItemRepository;

        public WireTypeCommandHandler(IClaimHelper claimHelper
            , IWireTypeRepository wireTypeRepository
            , IWireTypeService wireTypeService
            , IWireTypeGroupRepository wireTypeGroupRepository,
                IListItemRepository listItemRepository)
        {
            _claimHelper = claimHelper;
            _wireTypeRepository = wireTypeRepository;
            _wireTypeService = wireTypeService;
            _wireTypeGroupRepository = wireTypeGroupRepository;
            _listItemRepository = listItemRepository;
        }

        public Guid Handle(CreateWireType command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var wireTypeGroupId = _wireTypeGroupRepository.GetIdBy(command.WireTypeGroupGuid);

            //if (_wireTypeRepository.Exists(x => x.Name == command.Name && x.WireTypeGroupId == wireTypeGroupId && x.WireSize == command.WireSize))
            //    throw new BusinessException("0", "اطلاعات وارد شده تکراری است.");

            var wireType = new WireType(creator, wireTypeGroupId, command.Code, command.Name, command.WireSize, _wireTypeService);
            _wireTypeRepository.Create(wireType);
            return wireType.Guid;
        }

        public void Handle(EditWireType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var wireTypeGroupId = _wireTypeGroupRepository.GetIdBy(command.WireTypeGroupGuid);

            //if (_wireTypeRepository.Exists(x => x.Name == command.Name && x.WireTypeGroupId == wireTypeGroupId && x.WireSize == command.WireSize && x.Guid != command.Guid))
            //    throw new BusinessException("0", "اطلاعات وارد شده تکراری است.");

            var wireType = _wireTypeRepository.Load(command.Guid);
            wireType.Edit(actor, wireTypeGroupId, command.Code, command.Name, command.WireSize, _wireTypeService);
        }

        public void Handle(RemoveWireType command)
        {
            var wireType = _wireTypeRepository.Load(command.Guid);
            _wireTypeRepository.Delete(wireType);
        }
        public void Handle(ActivateWireType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var wireType = _wireTypeRepository.Load(command.Guid);
            wireType.Activate();
        }

        public void Handle(DeactivateWireType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var wireType = _wireTypeRepository.Load(command.Guid);
            wireType.Deactivate();
        }
    }
}
