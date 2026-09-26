using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Part;
using Ex.Domain.PartAgg.Service;
using Ex.Domain.PartAgg;
using Ex.Domain.PartGroupAgg;

namespace Ex.Application;

public class PartCommandHandler(
    IClaimHelper claimHelper,
    IPartRepository partRepository,
    IPartService partService,
    IPartGroupRepository partGroupRepository)
    :
        ICommandHandlerAsync<CreatePart, Guid>,
        ICommandHandlerAsync<EditPart>,
        ICommandHandler<RemovePart>,
        ICommandHandler<ActivatePart>,
        ICommandHandler<DeactivatePart>
{
    public async Task<Guid> Handle(CreatePart command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var partGroupId = await partGroupRepository.GetIdByAsync(command.PartGroupGuid);
        var part = new Part(creator, partGroupId, command.Name, command.StandardWireConsumption, partService);
        await partRepository.CreateAsync(part);

        return part.Guid;
    }

    public async Task Handle(EditPart command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var part = partRepository.Load(command.Guid);
        var partGroupId = await partGroupRepository.GetIdByAsync(command.PartGroupGuid);
        part.Edit(actor, partGroupId, command.Name, command.StandardWireConsumption, partService);
    }

    public void Handle(RemovePart command)
    {
        var part = partRepository.Load(command.Guid);
        partRepository.Delete(part);
    }
    public void Handle(ActivatePart command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var part = partRepository.Load(command.Guid);
        part.Activate();
    }

    public void Handle(DeactivatePart command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var part = partRepository.Load(command.Guid);
        part.Deactivate();
    }
}