using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Salon;
using Ex.Domain.SalonAgg.Service;
using Ex.Domain.SalonAgg;
using Ex.Domain.ListItemAgg;

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
        private readonly IListItemRepository _listItemRepository;

        public SalonCommandHandler(IClaimHelper claimHelper
            , ISalonRepository salonRepository
            , ISalonService salonService,
IListItemRepository listItemRepository)
        {
            _claimHelper = claimHelper;
            _salonRepository = salonRepository;
            _salonService = salonService;
            _listItemRepository = listItemRepository;
        }

        public Guid Handle(CreateSalon command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var type = _listItemRepository.GetIdBy(command.TypeGuid);

            var salon = new Salon(creator, command.Name, command.Code, type, command.HasGas, command.HasWire, command.HasWireScrew,
                command.HasPowder, _salonService);
            
            _salonRepository.Create(salon);
            return salon.Guid;
        }

        public void Handle(EditSalon command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var salon = _salonRepository.Load(command.Guid);
            var type = _listItemRepository.GetIdBy(command.TypeGuid);

            salon.Edit(actor, command.Name, command.Code, type, command.HasGas, command.HasWire, command.HasWireScrew,
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
