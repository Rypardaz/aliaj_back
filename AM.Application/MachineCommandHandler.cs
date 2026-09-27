using AM.Application.Contracts.Machine;
using AM.Domain.MachineAgg;
using AM.Domain.MachineAgg.Service;
using AM.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class MachineCommandHandler(
    IClaimHelper claimHelper,
    IMachineRepository machineRepository,
    IMachineService machineService,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreateMachine, Guid>,
        ICommandHandler<EditMachine>,
        ICommandHandler<RemoveMachine>,
        ICommandHandler<ActivateMachine>,
        ICommandHandler<DeactivateMachine>
{
    public Guid Handle(CreateMachine command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var salonId = salonRepository.GetIdBy(command.SalonGuid);
        var machine = new Machine(creator, command.Code, command.Name, salonId, command.HeadCount,
            command.Description, command.Ip, machineService);
        machineRepository.Create(machine);
        return machine.Guid;
    }

    public void Handle(EditMachine command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var machine = machineRepository.Load(command.Guid);
        var salonId = salonRepository.GetIdBy(command.SalonGuid);
        machine.Edit(actor, command.Code, command.Name, salonId, command.HeadCount, command.Description, command.Ip,
            machineService);
    }

    public void Handle(RemoveMachine command)
    {
        var machine = machineRepository.Load(command.Guid);
        machineRepository.Delete(machine);
    }

    public void Handle(ActivateMachine command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var machine = machineRepository.Load(command.Guid);
        machine.Activate();
    }

    public void Handle(DeactivateMachine command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var machine = machineRepository.Load(command.Guid);
        machine.Deactivate();
    }
}