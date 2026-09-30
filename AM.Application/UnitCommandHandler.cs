using AM.Application.Contracts.Unit;
using AM.Domain.UnitAgg;
using AM.Domain.UnitAgg.Service;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class UnitCommandHandler(
    IClaimHelper claimHelper,
    IUnitRepository unitRepository,
    IUnitService unitService)
    :
        ICommandHandler<CreateUnit, Guid>,
        ICommandHandler<EditUnit>,
        ICommandHandler<RemoveUnit>,
        ICommandHandler<ActivateUnit>,
        ICommandHandler<DeactivateUnit>
{
    public Guid Handle(CreateUnit command)
    {
        var creator = claimHelper.GetCurrentUserGuid();

        var unit = new Unit(creator, command.Code, command.Name, unitService);

        unitRepository.Create(unit);

        return unit.Guid;
    }

    public void Handle(EditUnit command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var unit = unitRepository.Load(command.Guid);

        unit.Edit(actor, command.Code, command.Name, unitService);
    }

    public void Handle(RemoveUnit command)
    {
        var unit = unitRepository.Load(command.Guid);
        unitRepository.Delete(unit);
    }

    public void Handle(ActivateUnit command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var unit = unitRepository.Load(command.Guid);
        unit.Activate();
    }

    public void Handle(DeactivateUnit command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var unit = unitRepository.Load(command.Guid);
        unit.Deactivate();
    }
}