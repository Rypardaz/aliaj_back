using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Personnel;
using Ex.Domain.PersonnelAgg.Service;
using Ex.Domain.PersonnelAgg;
using Ex.Domain.SalonAgg;

namespace Ex.Application
{
    public class PersonnelCommandHandler :
        ICommandHandlerAsync<CreatePersonnel, Guid>,
        ICommandHandlerAsync<EditPersonnel>,
        ICommandHandler<RemovePersonnel>,
        ICommandHandler<ActivatePersonnel>,
        ICommandHandler<DeactivatePersonnel>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IPersonnelService _personnelService;
        private readonly ISalonRepository _salonRepository;

        public PersonnelCommandHandler(IClaimHelper claimHelper, IPersonnelRepository personnelRepository,
            IPersonnelService personnelService, ISalonRepository salonRepository)
        {
            _claimHelper = claimHelper;
            _personnelRepository = personnelRepository;
            _personnelService = personnelService;
            _salonRepository = salonRepository;
        }

        public async Task<Guid> Handle(CreatePersonnel command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var salonId = await _salonRepository.GetIdByAsync(command.SalonGuid);
            var personnel = new Personnel(creator, command.Name, command.Code, command.Family, command.NationalCode,
                salonId, _personnelService);
            await _personnelRepository.CreateAsync(personnel);

            return personnel.Guid;
        }

        public async Task Handle(EditPersonnel command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var personnel = _personnelRepository.Load(command.Guid);
            var salonId = await _salonRepository.GetIdByAsync(command.SalonGuid);
            personnel.Edit(actor, command.Name, command.Code, command.Family, command.NationalCode, salonId,
                _personnelService);
        }

        public void Handle(RemovePersonnel command)
        {
            var personnel = _personnelRepository.Load(command.Guid);
            _personnelRepository.Delete(personnel);
        }

        public void Handle(ActivatePersonnel command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var personnel = _personnelRepository.Load(command.Guid);
            personnel.Activate();
        }

        public void Handle(DeactivatePersonnel command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var personnel = _personnelRepository.Load(command.Guid);
            personnel.Deactivate();
        }
    }
}