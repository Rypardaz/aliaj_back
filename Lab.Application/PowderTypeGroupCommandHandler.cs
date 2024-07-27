using Ex.Application.Contracts.PowderTypeGroup;
using Ex.Domain.PowderTypeGroupAgg.Service;
using Ex.Domain.PowderTypeGroupAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace Ex.Application
{
    public class PowderTypeGroupCommandHandler :
    ICommandHandler<CreatePowderTypeGroup, Guid>,
    ICommandHandler<EditPowderTypeGroup>,
    ICommandHandler<RemovePowderTypeGroup>,
    ICommandHandler<ActivatePowderTypeGroup>,
    ICommandHandler<DeactivatePowderTypeGroup>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IPowderTypeGroupRepository _powderTypeGroupRepository;
        private readonly IPowderTypeGroupService _powderTypeGroupService;

        public PowderTypeGroupCommandHandler(IClaimHelper claimHelper
            , IPowderTypeGroupRepository powderTypeGroupRepository
            , IPowderTypeGroupService powderTypeGroupService)
        {
            _claimHelper = claimHelper;
            _powderTypeGroupRepository = powderTypeGroupRepository;
            _powderTypeGroupService = powderTypeGroupService;
        }

        public Guid Handle(CreatePowderTypeGroup command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var powderTypeGroup = new PowderTypeGroup(creator, command.Name, _powderTypeGroupService);
            _powderTypeGroupRepository.Create(powderTypeGroup);
            return powderTypeGroup.Guid;
        }

        public void Handle(EditPowderTypeGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var powderTypeGroup = _powderTypeGroupRepository.Load(command.Guid);
            powderTypeGroup.Edit(actor, command.Name, _powderTypeGroupService);
        }

        public void Handle(RemovePowderTypeGroup command)
        {
            var powderTypeGroup = _powderTypeGroupRepository.Load(command.Guid);
            _powderTypeGroupRepository.Delete(powderTypeGroup);
        }
        public void Handle(ActivatePowderTypeGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var powderTypeGroup = _powderTypeGroupRepository.Load(command.Guid);
            powderTypeGroup.Activate();
        }

        public void Handle(DeactivatePowderTypeGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var powderTypeGroup = _powderTypeGroupRepository.Load(command.Guid);
            powderTypeGroup.Deactivate();
        }
    }
}
