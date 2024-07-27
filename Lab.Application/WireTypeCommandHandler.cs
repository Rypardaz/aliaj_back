using Ex.Application.Contracts.WireType;
using Ex.Domain.WireTypeAgg.Service;
using Ex.Domain.WireTypeAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Domain.WireTypeGroupAgg;

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

        public WireTypeCommandHandler(IClaimHelper claimHelper
            , IWireTypeRepository wireTypeRepository
            , IWireTypeService wireTypeService
            , IWireTypeGroupRepository wireTypeGroupRepository)
        {
            _claimHelper = claimHelper;
            _wireTypeRepository = wireTypeRepository;
            _wireTypeService = wireTypeService;
            _wireTypeGroupRepository = wireTypeGroupRepository;
        }

        public Guid Handle(CreateWireType command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var wireTypeGroupId = _wireTypeGroupRepository.GetIdBy(command.WireTypeGroupGuid);
            var wireType = new WireType(creator, wireTypeGroupId, command.Name, command.WireSize, _wireTypeService);
            _wireTypeRepository.Create(wireType);
            return wireType.Guid;
        }

        public void Handle(EditWireType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var wireType = _wireTypeRepository.Load(command.Guid);
            var wireTypeGroupId = _wireTypeGroupRepository.GetIdBy(command.WireTypeGroupGuid);
            wireType.Edit(actor, wireTypeGroupId, command.Name, command.WireSize, _wireTypeService);
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
