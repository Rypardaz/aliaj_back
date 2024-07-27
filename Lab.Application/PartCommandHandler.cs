using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Part;
using Ex.Domain.PartAgg.Service;
using Ex.Domain.PartAgg;
using Ex.Domain.PartGroupAgg;

namespace Ex.Application
{
    public class PartCommandHandler :
    ICommandHandlerAsync<CreatePart, Guid>,
    ICommandHandlerAsync<EditPart>,
    ICommandHandler<RemovePart>,
    ICommandHandler<ActivatePart>,
    ICommandHandler<DeactivatePart>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IPartRepository _partRepository;
        private readonly IPartService _partService;
        private readonly IPartGroupRepository _partGroupRepository;

        public PartCommandHandler(IClaimHelper claimHelper, IPartRepository partRepository, IPartService partService, IPartGroupRepository partGroupRepository)
        {
            _claimHelper = claimHelper;
            _partRepository = partRepository;
            _partService = partService;
            _partGroupRepository = partGroupRepository;
        }

        public async Task<Guid> Handle(CreatePart command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var partGroupId = await _partGroupRepository.GetIdByAsync(command.PartGroupGuid);
            var part = new Part(creator, partGroupId, command.Name, command.StandardWireConsumption, _partService);
            await _partRepository.CreateAsync(part);

            return part.Guid;
        }

        public async Task Handle(EditPart command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var part = _partRepository.Load(command.Guid);
            var partGroupId = await _partGroupRepository.GetIdByAsync(command.PartGroupGuid);
            part.Edit(actor, partGroupId, command.Name, command.StandardWireConsumption, _partService);
        }

        public void Handle(RemovePart command)
        {
            var part = _partRepository.Load(command.Guid);
            _partRepository.Delete(part);
        }
        public void Handle(ActivatePart command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var part = _partRepository.Load(command.Guid);
            part.Activate();
        }

        public void Handle(DeactivatePart command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var part = _partRepository.Load(command.Guid);
            part.Deactivate();
        }
    }
}
