using Ex.Application.Contracts.PartGroup;
using Ex.Domain.PartGroupAgg.Service;
using Ex.Domain.PartGroupAgg;
using Ex.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace Ex.Application
{
    public class PartGroupCommandHandler :
        ICommandHandler<CreatePartGroup, Guid>,
        ICommandHandler<EditPartGroup>,
        ICommandHandler<RemovePartGroup>,
        ICommandHandler<ActivatePartGroup>,
        ICommandHandler<DeactivatePartGroup>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IPartGroupRepository _partGroupRepository;
        private readonly IPartGroupService _partGroupService;
        private readonly ISalonRepository _salonRepository;

        public PartGroupCommandHandler(IClaimHelper claimHelper
            , IPartGroupRepository partGroupRepository
            , IPartGroupService partGroupService, ISalonRepository salonRepository)
        {
            _claimHelper = claimHelper;
            _partGroupRepository = partGroupRepository;
            _partGroupService = partGroupService;
            _salonRepository = salonRepository;
        }

        public Guid Handle(CreatePartGroup command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var salonId = _salonRepository.GetIdBy(command.SalonGuid);

            var partGroup = new PartGroup(creator, command.Name, salonId, _partGroupService);
            _partGroupRepository.Create(partGroup);
            return partGroup.Guid;
        }

        public void Handle(EditPartGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var partGroup = _partGroupRepository.Load(command.Guid);
            var salonId = _salonRepository.GetIdBy(command.SalonGuid);

            partGroup.Edit(actor, command.Name, salonId, _partGroupService);
        }

        public void Handle(RemovePartGroup command)
        {
            var partGroup = _partGroupRepository.Load(command.Guid);
            _partGroupRepository.Delete(partGroup);
        }

        public void Handle(ActivatePartGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var partGroup = _partGroupRepository.Load(command.Guid);
            partGroup.Activate();
        }

        public void Handle(DeactivatePartGroup command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var partGroup = _partGroupRepository.Load(command.Guid);
            partGroup.Deactivate();
        }
    }
}