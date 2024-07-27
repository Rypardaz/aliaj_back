using Ex.Domain.MachineAgg;
using Ex.Domain.MachineLogAgg;
using Ex.Application.Contracts.MachineLog;
using PhoenixFramework.Application.Command;

namespace Ex.Application
{
    public class MachineLogCommandHandler : ICommandHandler<CreateMachineLog>
    {
        private readonly IMachineLogRepository _machineLogRepository;
        private readonly IMachineRepository _machineRepository;

        public MachineLogCommandHandler(IMachineLogRepository machineLogRepository, IMachineRepository machineRepository)
        {
            _machineLogRepository = machineLogRepository;
            _machineRepository = machineRepository;
        }

        public void Handle(CreateMachineLog command)
        {
            var machineId = _machineRepository.GetIdBy(command.DL);
            var machineLog = new MachineLog(machineId, command.Time, command.V1, command.I1, command.WF1, command.RPM1, command.T1, command.V2, command.I2, command.WF2, command.RPM2, command.T2);
            
            _machineLogRepository.Create(machineLog);
            _machineLogRepository.SaveChanges();
        }
    }
}
