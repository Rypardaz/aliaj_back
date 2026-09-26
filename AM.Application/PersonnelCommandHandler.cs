using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Personnel;
using Ex.Domain.PersonnelAgg.Service;
using Ex.Domain.PersonnelAgg;
using Ex.Domain.SalonAgg;

namespace Ex.Application;

public class PersonnelCommandHandler(
    IClaimHelper claimHelper,
    IPersonnelRepository personnelRepository,
    IPersonnelService personnelService,
    ISalonRepository salonRepository)
    :
        ICommandHandlerAsync<CreatePersonnel, Guid>,
        ICommandHandlerAsync<EditPersonnel>,
        ICommandHandler<RemovePersonnel>,
        ICommandHandler<ActivatePersonnel>,
        ICommandHandler<DeactivatePersonnel>
{
    public async Task<Guid> Handle(CreatePersonnel command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var salonId = await salonRepository.GetIdByAsync(command.SalonGuid);
        var personnel = new Personnel(creator, command.Name, command.Code, command.Family, command.NationalCode,
            salonId, personnelService);
        await personnelRepository.CreateAsync(personnel);

        return personnel.Guid;
    }

    public async Task Handle(EditPersonnel command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var personnel = personnelRepository.Load(command.Guid);
        var salonId = await salonRepository.GetIdByAsync(command.SalonGuid);
        personnel.Edit(actor, command.Name, command.Code, command.Family, command.NationalCode, salonId,
            personnelService);
    }

    public void Handle(RemovePersonnel command)
    {
        var personnel = personnelRepository.Load(command.Guid);
        personnelRepository.Delete(personnel);
    }

    public void Handle(ActivatePersonnel command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var personnel = personnelRepository.Load(command.Guid);
        personnel.Activate();
    }

    public void Handle(DeactivatePersonnel command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var personnel = personnelRepository.Load(command.Guid);
        personnel.Deactivate();
    }
}