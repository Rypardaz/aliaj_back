using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Salon;
using Ex.Domain.SalonAgg.Service;
using Ex.Domain.SalonAgg;

namespace Ex.Application
{
    public class SalonCommandHandler :
    ICommandHandler<CreateSalon, Guid>,
    ICommandHandler<EditSalon>,
    ICommandHandler<RemoveSalon>,
    ICommandHandler<ActivateSalon>,
    ICommandHandler<DeactivateSalon>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly ISalonRepository _salonRepository;
        private readonly ISalonService _salonService;

        public SalonCommandHandler(IClaimHelper claimHelper
            , ISalonRepository salonRepository
            , ISalonService salonService)
        {
            _claimHelper = claimHelper;
            _salonRepository = salonRepository;
            _salonService = salonService;
        }

        public Guid Handle(CreateSalon command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var salon = new Salon(creator, command.Name, command.HasGas, command.HasWire, command.HasWireScrew,
                command.HasPowder, _salonService);
            _salonRepository.Create(salon);
            return salon.Guid;
        }

        public void Handle(EditSalon command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var salon = _salonRepository.Load(command.Guid);
            salon.Edit(actor, command.Name, command.HasGas, command.HasWire, command.HasWireScrew,
                command.HasPowder, _salonService);
        }

        public void Handle(RemoveSalon command)
        {
            var salon = _salonRepository.Load(command.Guid);
            _salonRepository.Delete(salon);
        }
        public void Handle(ActivateSalon command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var salon = _salonRepository.Load(command.Guid);
            salon.Activate();
        }

        public void Handle(DeactivateSalon command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var salon = _salonRepository.Load(command.Guid);
            salon.Deactivate();
        }
    }
}
