using Ex.Application.Contracts.GasTypeGroup;
using Ex.Domain.GasTypeGroupAgg.Service;
using Ex.Domain.GasTypeGroupAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace Ex.Application
{
    public class GasTypeGroupCommandHandler :
        ICommandHandler<CreateGasTypeGroup, Guid>,
        ICommandHandler<EditGasTypeGroup>,
        ICommandHandler<RemoveGasTypeGroup>,
        ICommandHandler<ActivateGasTypeGroup>,
        ICommandHandler<DeactivateGasTypeGroup>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IGasTypeGroupRepository _gasTypeGroupRepository;
        private readonly IGasTypeGroupService _gasTypeGroupService;

        public GasTypeGroupCommandHandler(IClaimHelper claimHelper
            , IGasTypeGroupRepository gasTypeGroupRepository
            , IGasTypeGroupService gasTypeGroupService)
        {
            _claimHelper = claimHelper;
            _gasTypeGroupRepository = gasTypeGroupRepository;
            _gasTypeGroupService = gasTypeGroupService;
        }

        public Guid Handle(CreateGasTypeGroup command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var gasTypeGroup = new GasTypeGroup(creator, command.Name, _gasTypeGroupService);
            _gasTypeGroupRepository.Create(gasTypeGroup);
            return gasTypeGroup.Guid;
        }

        public void Handle(EditGasTypeGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var gasTypeGroup = _gasTypeGroupRepository.Load(command.Guid);
            gasTypeGroup.Edit(actor, command.Name, _gasTypeGroupService);
        }

        public void Handle(RemoveGasTypeGroup command)
        {
            var gasTypeGroup = _gasTypeGroupRepository.Load(command.Guid);
            _gasTypeGroupRepository.Delete(gasTypeGroup);
        }
        public void Handle(ActivateGasTypeGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var gasTypeGroup = _gasTypeGroupRepository.Load(command.Guid);
            gasTypeGroup.Activate();
        }

        public void Handle(DeactivateGasTypeGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var gasTypeGroup = _gasTypeGroupRepository.Load(command.Guid);
            gasTypeGroup.Deactivate();
        }
    }
}
