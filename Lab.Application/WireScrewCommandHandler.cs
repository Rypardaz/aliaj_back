using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.WireScrew;
using Ex.Domain.WireScrewAgg.Service;
using Ex.Domain.WireScrewAgg;
using Ex.Domain.WireTypeAgg;

namespace Ex.Application
{
    public class WireScrewCommandHandler :
        ICommandHandler<CreateWireScrew, Guid>,
        ICommandHandler<EditWireScrew>,
        ICommandHandler<RemoveWireScrew>,
        ICommandHandler<ActivateWireScrew>,
        ICommandHandler<DeactivateWireScrew>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IWireScrewRepository _wireScrewRepository;
        private readonly IWireScrewService _wireScrewService;
        private readonly IWireTypeRepository _wireTypeRepository;

        public WireScrewCommandHandler(IClaimHelper claimHelper
            , IWireScrewRepository wireScrewRepository
            , IWireScrewService wireScrewService
            , IWireTypeRepository wireTypeRepository)
        {
            _claimHelper = claimHelper;
            _wireScrewRepository = wireScrewRepository;
            _wireScrewService = wireScrewService;
            _wireTypeRepository = wireTypeRepository;
        }

        public Guid Handle(CreateWireScrew command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var wireTypeId = _wireTypeRepository.GetIdBy(command.WireTypeGuid);
            var wireScrew = new WireScrew(creator, wireTypeId, command.Screw, command.Qty, _wireScrewService);
            _wireScrewRepository.Create(wireScrew);
            return wireScrew.Guid;
        }

        public void Handle(EditWireScrew command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var wireScrew = _wireScrewRepository.Load(command.Guid);
            var wireTypeId = _wireTypeRepository.GetIdBy(command.WireTypeGuid);
            wireScrew.Edit(actor, wireTypeId, command.Screw, command.Qty, _wireScrewService);
        }

        public void Handle(RemoveWireScrew command)
        {
            var wireScrew = _wireScrewRepository.Load(command.Guid);
            _wireScrewRepository.Delete(wireScrew);
        }
        public void Handle(ActivateWireScrew command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var wireScrew = _wireScrewRepository.Load(command.Guid);
            wireScrew.Activate();
        }

        public void Handle(DeactivateWireScrew command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var wireScrew = _wireScrewRepository.Load(command.Guid);
            wireScrew.Deactivate();
        }
    }
}
