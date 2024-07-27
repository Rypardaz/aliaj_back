using Ex.Application.Contracts.WireTypeGroup;
using Ex.Domain.WireTypeGroupAgg.Service;
using Ex.Domain.WireTypeGroupAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace Ex.Application
{
    public class WireTypeGroupCommandHandler :
    ICommandHandler<CreateWireTypeGroup, Guid>,
    ICommandHandler<EditWireTypeGroup>,
    ICommandHandler<RemoveWireTypeGroup>,
    ICommandHandler<ActivateWireTypeGroup>,
    ICommandHandler<DeactivateWireTypeGroup>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IWireTypeGroupRepository _wireTypeGroupRepository;
        private readonly IWireTypeGroupService _wireTypeGroupService;

        public WireTypeGroupCommandHandler(IClaimHelper claimHelper
            , IWireTypeGroupRepository wireTypeGroupRepository
            , IWireTypeGroupService wireTypeGroupService)
        {
            _claimHelper = claimHelper;
            _wireTypeGroupRepository = wireTypeGroupRepository;
            _wireTypeGroupService = wireTypeGroupService;
        }

        public Guid Handle(CreateWireTypeGroup command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var wireTypeGroup = new WireTypeGroup(creator, command.Name, _wireTypeGroupService);
            _wireTypeGroupRepository.Create(wireTypeGroup);
            return wireTypeGroup.Guid;
        }

        public void Handle(EditWireTypeGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var wireTypeGroup = _wireTypeGroupRepository.Load(command.Guid);
            wireTypeGroup.Edit(actor, command.Name, _wireTypeGroupService);
        }

        public void Handle(RemoveWireTypeGroup command)
        {
            var wireTypeGroup = _wireTypeGroupRepository.Load(command.Guid);
            _wireTypeGroupRepository.Delete(wireTypeGroup);
        }
        public void Handle(ActivateWireTypeGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var wireTypeGroup = _wireTypeGroupRepository.Load(command.Guid);
            wireTypeGroup.Activate();
        }

        public void Handle(DeactivateWireTypeGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var wireTypeGroup = _wireTypeGroupRepository.Load(command.Guid);
            wireTypeGroup.Deactivate();
        }
    }
}
