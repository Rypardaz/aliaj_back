using AM.Application.Contracts.Material;
using AM.Domain.MaterialAgg;
using AM.Domain.MaterialAgg.Service;
using AM.Domain.UnitAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;


public class MaterialCommandHandler(
    IClaimHelper claimHelper,
    IMaterialRepository materialRepository,
    IMaterialService materialService,
    IUnitRepository unitRepository)
    :
        ICommandHandler<CreateMaterial, Guid>,
        ICommandHandler<EditMaterial>,
        ICommandHandler<RemoveMaterial>,
        ICommandHandler<ActivateMaterial>,
        ICommandHandler<DeactivateMaterial>
{
    public Guid Handle(CreateMaterial command)
    {
        var creator = claimHelper.GetCurrentUserGuid();

        long unitId;
        unitId = unitRepository.GetIdBy(command.UnitGuid);

        var material = new Material(creator, unitId, command.Code, command.Name, materialService);

        materialRepository.Create(material);

        return material.Guid;
    }

    public void Handle(EditMaterial command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var material = materialRepository.Load(command.Guid);

        long unitId;
        unitId = unitRepository.GetIdBy(command.UnitGuid);

        material.Edit(actor, unitId, command.Code, command.Name, materialService);
    }

    public void Handle(RemoveMaterial command)
    {
        var material = materialRepository.Load(command.Guid);
        materialRepository.Delete(material);
    }

    public void Handle(ActivateMaterial command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var material = materialRepository.Load(command.Guid);
        material.Activate();
    }

    public void Handle(DeactivateMaterial command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var material = materialRepository.Load(command.Guid);
        material.Deactivate();
    }
}