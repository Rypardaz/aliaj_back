using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Machine;
using Ex.Domain.MachineAgg.Service;
using Ex.Domain.MachineAgg;
using Ex.Domain.SalonAgg;

namespace Ex.Application
{
    public class MachineCommandHandler :
    ICommandHandler<CreateMachine, Guid>,
    ICommandHandler<EditMachine>,
    ICommandHandler<RemoveMachine>,
    ICommandHandler<ActivateMachine>,
    ICommandHandler<DeactivateMachine>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IMachineRepository _machineRepository;
        private readonly IMachineService _machineService;
        private readonly ISalonRepository _salonRepository;

        public MachineCommandHandler(IClaimHelper claimHelper
            , IMachineRepository machineRepository
            , IMachineService machineService
            , ISalonRepository salonRepository)
        {
            _claimHelper = claimHelper;
            _machineRepository = machineRepository;
            _machineService = machineService;
            _salonRepository = salonRepository;
        }

        public Guid Handle(CreateMachine command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var salonId = _salonRepository.GetIdBy(command.SalonGuid);
            var machine = new Machine(creator, command.Code, command.Name, salonId, command.HeadCount, command.Capacity, command.Description, _machineService);
            _machineRepository.Create(machine);
            return machine.Guid;
        }

        public void Handle(EditMachine command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var machine = _machineRepository.Load(command.Guid);
            var salonId = _salonRepository.GetIdBy(command.SalonGuid);
            machine.Edit(actor, command.Code, command.Name, salonId, command.HeadCount, command.Capacity, command.Description, _machineService);
        }

        public void Handle(RemoveMachine command)
        {
            var machine = _machineRepository.Load(command.Guid);
            _machineRepository.Delete(machine);
        }
        public void Handle(ActivateMachine command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var machine = _machineRepository.Load(command.Guid);
            machine.Activate();
        }

        public void Handle(DeactivateMachine command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var machine = _machineRepository.Load(command.Guid);
            machine.Deactivate();
        }
    }
}
